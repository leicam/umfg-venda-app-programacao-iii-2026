using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using umfg.venda.app.programacao.iii._2026.Abstracoes;
using umfg.venda.app.programacao.iii._2026.ViewModels;

namespace umfg.venda.app.programacao.iii._2026.Comandos;

internal sealed class AdicionarItemCommand : AbstractCommand
{
    //o 'object' é a classe pai de todos os objetos em C#
    public override void Execute(object? parameter)
    {
        //a palavra reservada 'as' converter o objeto no tipo que definimos
        //var vm = parameter as ListarProdutosViewModel;

        //esta e uma variacao, onde testo se o parametro pode ser
        //convertido para o tipo ListarProdutosViewModel e caso correto
        //a variavel vm é criada
        if (!(parameter is ListarProdutosViewModel vm))
        {
            MessageBox.Show("Erro ao adicionar item!", "Remover item", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        //fail first - garante que nao ocorrera erro em tempo de execução
        if (vm is null)
        {
            MessageBox.Show("Erro ao adicionar item!", "Remover item", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (vm.ProdutoSelecionado is null || vm.ProdutoSelecionado.Valor <= decimal.Zero)
        {
            MessageBox.Show("Nenhum item selecionado!", "Remover item", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var mensagem = "Deseja realmente incluir este item no carrinho?";
        var result = MessageBox.Show(mensagem, "Adicionar item", MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (!MessageBoxResult.Yes.Equals(result))
            return;

        vm.Pedido.Lista.Add(vm.ProdutoSelecionado);
        vm.Pedido.Subtotal = vm.Pedido.Lista.Sum(x => x.Valor);
        vm.RemoverItem.RaiseCanExecuteChanged();
        vm.ReceberPedido.RaiseCanExecuteChanged();
    }
}
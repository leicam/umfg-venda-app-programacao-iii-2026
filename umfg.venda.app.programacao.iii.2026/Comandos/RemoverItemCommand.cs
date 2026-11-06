using System.Windows;
using umfg.venda.app.programacao.iii._2026.Abstracoes;
using umfg.venda.app.programacao.iii._2026.ViewModels;

namespace umfg.venda.app.programacao.iii._2026.Comandos;

internal sealed class RemoverItemCommand : AbstractCommand
{
    public override bool CanExecute(object? parameter)
    {
        if (!(parameter is ListarProdutosViewModel vm))
        {
            MessageBox.Show("Erro ao remover item!");
            return false;
        }

        return vm.Pedido.Lista.Any();
    }

    public override void Execute(object? parameter)
    {
        if (!(parameter is ListarProdutosViewModel vm))
        {
            MessageBox.Show("Erro ao remover item!");
            return;
        }

        if (vm is null)
        {
            MessageBox.Show("Erro ao remover item!", "Remover item", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (vm.ProdutoSelecionado is null 
            || vm.ProdutoSelecionado.Valor <= decimal.Zero)
        {
            MessageBox.Show("Nenhum item selecionado!", "Remover item", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var produtoLista = vm.Pedido.Lista
            .FirstOrDefault(x => x.Referencia == vm.ProdutoSelecionado.Referencia);

        if (produtoLista is null)
        {
            MessageBox.Show($"Produto {vm.ProdutoSelecionado.Descricao}" +
                $" não encontrado no carrinho!", "Remover item", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }
        
        var mensagem = $"Deseja realmente remover o item {produtoLista.Descricao} do carrinho?";
        var result = MessageBox.Show(mensagem, "Remover item", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (!MessageBoxResult.Yes.Equals(result))
            return;

        vm.Pedido.Lista.Remove(produtoLista);
        vm.Pedido.Subtotal = vm.Pedido.Lista.Sum(x => x.Valor);
        vm.RemoverItem.RaiseCanExecuteChanged();
        vm.ReceberPedido.RaiseCanExecuteChanged();
    }
}
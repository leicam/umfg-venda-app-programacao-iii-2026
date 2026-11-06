using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using umfg.venda.app.programacao.iii._2026.Abstracoes;
using umfg.venda.app.programacao.iii._2026.UserControls;
using umfg.venda.app.programacao.iii._2026.ViewModels;

namespace umfg.venda.app.programacao.iii._2026.Comandos;

internal sealed class ReceberPedidoCommand : AbstractCommand
{
    public override bool CanExecute(object? parameter)
    {
        if (!(parameter is ListarProdutosViewModel vm))
        {
            MessageBox.Show("Erro ao receber pedido!");
            return false;
        }

        return vm.Pedido.Lista.Any();
    }

    public override void Execute(object? parameter)
    {
        if (!(parameter is ListarProdutosViewModel vm))
        {
            MessageBox.Show("Erro ao receber pedido!");
            return;
        }

        ucReceberPedido.Show(vm.MainWindow, vm.Pedido);
    }
}
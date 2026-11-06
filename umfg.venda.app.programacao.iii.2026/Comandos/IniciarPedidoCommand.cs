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

internal sealed class IniciarPedidoCommand : AbstractCommand
{
    public override void Execute(object? parameter)
    {
        ucListarProdutos.Show(parameter as MainWindowViewModel);
    }
}

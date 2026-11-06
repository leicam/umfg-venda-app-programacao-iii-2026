using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using umfg.venda.app.programacao.iii._2026.Interfaces;
using umfg.venda.app.programacao.iii._2026.Modelos;
using umfg.venda.app.programacao.iii._2026.ViewModels;

namespace umfg.venda.app.programacao.iii._2026.UserControls;

/// <summary>
/// Interação lógica para ucListarProdutos.xam
/// </summary>
public partial class ucListarProdutos : UserControl
{
    private ucListarProdutos(IObserver observer)
    {
        InitializeComponent();
        DataContext = new ListarProdutosViewModel(observer, this);
    }

    private ucListarProdutos(IObserver observer, PedidoModel pedido)
    {
        InitializeComponent();
        DataContext = new ListarProdutosViewModel(observer, this, pedido);
    }

    internal static void Show(IObserver observer)
        => (new ucListarProdutos(observer)
                .DataContext as ListarProdutosViewModel).Notify();

    internal static void Show(IObserver observer, PedidoModel pedido)
        => (new ucListarProdutos(observer, pedido)
                .DataContext as ListarProdutosViewModel).Notify();
}

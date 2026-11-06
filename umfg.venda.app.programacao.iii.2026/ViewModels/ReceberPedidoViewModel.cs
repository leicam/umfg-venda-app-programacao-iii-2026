using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using umfg.venda.app.programacao.iii._2026.Abstracoes;
using umfg.venda.app.programacao.iii._2026.Comandos;
using umfg.venda.app.programacao.iii._2026.Interfaces;
using umfg.venda.app.programacao.iii._2026.Modelos;

namespace umfg.venda.app.programacao.iii._2026.ViewModels;

internal sealed class ReceberPedidoViewModel : AbstractViewModel
{
    private string _numeroCartao = string.Empty;
    private string _cvv = string.Empty;
    private DateTime _dataValidade = DateTime.Today;
    private PedidoModel _pedido;

    public string NumeroCartao 
    { 
        get => _numeroCartao;
        set => SetField(ref _numeroCartao, value);
    }

    public string CVV
    {
        get => _cvv;
        set => SetField(ref _cvv, value);
    }

    public DateTime DataValidade
    {
        get => _dataValidade;
        set => SetField(ref _dataValidade, value);
    }

    public PedidoModel Pedido 
    { 
        get => _pedido;
        set => SetField(ref _pedido, value);
    }

    public bool IsInicio { get; set; } = false;

    public ConfirmarPagamentoCommand ConfirmarPagamento { get; private set; } = new();
    public CancelarPagamentoCommand CancelarPagamento { get; private set; } = new();

    public ReceberPedidoViewModel(UserControl userControl, IObserver observer, PedidoModel pedido) 
        : base("Receber Pedido")
    {
        UserControl = userControl ?? throw new ArgumentNullException(nameof(userControl));
        Pedido = pedido ?? throw new ArgumentNullException(nameof(pedido));
        MainWindow = observer ?? throw new ArgumentNullException(nameof(observer));

        Add(observer);
    }
}

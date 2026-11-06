using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umfg.venda.app.programacao.iii._2026.Abstracoes;
using umfg.venda.app.programacao.iii._2026.Comandos;
using umfg.venda.app.programacao.iii._2026.Interfaces;

namespace umfg.venda.app.programacao.iii._2026.ViewModels;

internal sealed class MainWindowViewModel : AbstractViewModel, IObserver
{
    private const string C_TITULO = "Menu Principal";
    public IniciarPedidoCommand IniciarPedido { get; private set; } = new();

    public MainWindowViewModel() : base(C_TITULO)
    {
    }

    public void Update(ISubject subject)
    {
        Titulo = C_TITULO;

        //identificar se o inscrito é a tela de listar produtos
        //navegar para a tela listar produtos
        if (subject is ListarProdutosViewModel)
        {
            UserControl = (subject as ListarProdutosViewModel).UserControl;
            Titulo = (subject as ListarProdutosViewModel).Titulo;
        }

        //identificar se o inscrito é a tela de pagamento
        //navegar para tela de inicio
        if (subject is ReceberPedidoViewModel)
        {
            if ((subject as ReceberPedidoViewModel).IsInicio)
            {
                UserControl = null;
                return;
            }

            UserControl = (subject as ReceberPedidoViewModel).UserControl;
            Titulo = (subject as ReceberPedidoViewModel).Titulo;
        }
    }
}
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using umfg.venda.app.programacao.iii._2026.Abstracoes;
using umfg.venda.app.programacao.iii._2026.Comandos;
using umfg.venda.app.programacao.iii._2026.Interfaces;
using umfg.venda.app.programacao.iii._2026.Modelos;

namespace umfg.venda.app.programacao.iii._2026.ViewModels;

internal sealed class ListarProdutosViewModel : AbstractViewModel
{
    private ObservableCollection<ProdutoModel> _lista = [];
    private ProdutoModel _produtoSelecionado = new();
    private PedidoModel _pedido = new();

    public ObservableCollection<ProdutoModel> Lista
    { 
        get => _lista;
        set => SetField(ref _lista, value);
    }

    public ProdutoModel ProdutoSelecionado 
    { 
        get => _produtoSelecionado;
        set => SetField(ref _produtoSelecionado, value);
    }

    public PedidoModel Pedido
    {
        get => _pedido;
        set => SetField(ref _pedido, value);
    }

    public AdicionarItemCommand AdicionarItem { get; private set; } = new();
    public RemoverItemCommand RemoverItem { get; private set; } = new();
    public ReceberPedidoCommand ReceberPedido { get; private set; } = new();

    public ListarProdutosViewModel(IObserver observer, UserControl userControl) 
        : base("Listagem de Produtos")
    {
        UserControl = userControl;
        MainWindow = observer;

        Add(observer);
        CarregarProdutos();
    }

    public ListarProdutosViewModel(IObserver observer, UserControl userControl,
        PedidoModel pedido) : this(observer, userControl)
    {
        Pedido = pedido;
    }

    private void CarregarProdutos()
    {
        Lista.Clear();
        
        var diretorioBase = Path.Combine(AppContext.BaseDirectory,
            "Resources", "Imagens");

        //"../imagens" exemplo de diretorio relativo
        //"c://teste/imagens" exemplo de diretorio absoluto

        Lista.Add(new()
        {
            Imagem = new BitmapImage(new Uri(Path.Combine(diretorioBase, "batata.png"),
                UriKind.RelativeOrAbsolute)),
            Descricao = "Batata Frita 300gr",
            Referencia = "0001",
            Valor = 10.99m,
        });

        Lista.Add(new()
        {
            Imagem = new BitmapImage(new Uri(Path.Combine(diretorioBase, "lanche.png"),
        UriKind.RelativeOrAbsolute)),
            Descricao = "Big Mac 350gr",
            Referencia = "0002",
            Valor = 25.99m,
        });

        Lista.Add(new()
        {
            Imagem = new BitmapImage(new Uri(Path.Combine(diretorioBase, "refrigerante.png"),
        UriKind.RelativeOrAbsolute)),
            Descricao = "Refrigerante Refil 500ml",
            Referencia = "0003",
            Valor = 10.99m,
        });

        Lista.Add(new()
        {
            Imagem = new BitmapImage(new Uri(Path.Combine(diretorioBase, "combo.png"),
        UriKind.RelativeOrAbsolute)),
            Descricao = "Combo Big Mac 350gr + Batata 300gr + Refil 500ml",
            Referencia = "0004",
            Valor = 45.99m,
        });

        Lista.Add(new()
        {
            Imagem = new BitmapImage(new Uri(Path.Combine(diretorioBase, "mcflurry.png"),
UriKind.RelativeOrAbsolute)),
            Descricao = "Mc Flurry Ovo Maltine 200ml",
            Referencia = "0005",
            Valor = 15.99m,
        });
    }
}
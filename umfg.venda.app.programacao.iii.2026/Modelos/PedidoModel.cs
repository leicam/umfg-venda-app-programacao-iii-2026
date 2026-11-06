using System.Collections.ObjectModel;
using umfg.venda.app.programacao.iii._2026.Abstracoes;

namespace umfg.venda.app.programacao.iii._2026.Modelos;

internal sealed class PedidoModel : AbstractModel
{
    private Guid _id = Guid.Empty;
    private ObservableCollection<ProdutoModel> _lista = [];
    private decimal _subtotal = decimal.Zero;

    public Guid Id 
    { 
        get => _id;
        set => SetField(ref _id, value);
    }

    public ObservableCollection<ProdutoModel> Lista
    {
        get => _lista;
        set => SetField(ref _lista, value);
    }

    public decimal Subtotal
    {
        get => _subtotal;
        set => SetField(ref _subtotal, value);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using umfg.venda.app.programacao.iii._2026.Abstracoes;

namespace umfg.venda.app.programacao.iii._2026.Modelos;

internal sealed class ProdutoModel : AbstractModel
{
    private Guid _id = Guid.Empty;
    private ImageSource _imagem; 
    private string _referencia = string.Empty;
    private string _descricao = string.Empty;
    private decimal _valor = decimal.Zero;

    public Guid Id 
    { 
        get => _id;
        set => SetField(ref _id, value);
    }

    public ImageSource Imagem 
    { 
        get => _imagem;
        set => SetField(ref _imagem, value);
    }

    public string Referencia
    {
        get => _referencia;
        set => SetField(ref _referencia, value);
    }

    public string Descricao
    {
        get => _descricao;
        set => SetField(ref _descricao, value);
    }

    public decimal Valor
    {
        get => _valor;
        set => SetField(ref _valor, value);
    }
}
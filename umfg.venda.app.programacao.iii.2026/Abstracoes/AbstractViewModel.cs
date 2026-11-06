using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using umfg.venda.app.programacao.iii._2026.Interfaces;

namespace umfg.venda.app.programacao.iii._2026.Abstracoes;

internal abstract class AbstractViewModel : AbstractNotifyPropertyChange, ISubject
{
    private ICollection<IObserver> _observers = [];
    private string _titulo = string.Empty;
    private UserControl? _userControl = null;

    public string Titulo 
    { 
        get => _titulo;
        set => SetField(ref _titulo, value);
    }

    public UserControl? UserControl 
    {
        get => _userControl;
        protected set => SetField(ref _userControl, value);
    }

    public IObserver MainWindow { get; protected set; }

    protected AbstractViewModel(string titulo)
    {
        Titulo = titulo ?? throw new ArgumentNullException(nameof(titulo));
    }

    public void Add(IObserver observer) => _observers.Add(observer);    
    public void Remove(IObserver observer) => _observers.Remove(observer);    

    public void Notify()
    {
        foreach (var observer in _observers)
            observer.Update(this);
    }
}
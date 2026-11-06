using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace umfg.venda.app.programacao.iii._2026.Abstracoes;

internal abstract class AbstractCommand : AbstractNotifyPropertyChange, ICommand
{
    public event EventHandler? CanExecuteChanged;

    //virtual permite que o método seja sobreescrito
    public virtual bool CanExecute(object? parameter) => true;

    public abstract void Execute(object? parameter);

    public void RaiseCanExecuteChanged()
        => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
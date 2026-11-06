using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace umfg.venda.app.programacao.iii._2026.Interfaces;

interface ISubject
{
    void Add(IObserver observer);
    void Remove(IObserver observer);
    void Notify();
}

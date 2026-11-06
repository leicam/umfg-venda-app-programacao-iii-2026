using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace umfg.venda.app.programacao.iii._2026.Interfaces;

interface IObserver
{
    void Update(ISubject subject);
}

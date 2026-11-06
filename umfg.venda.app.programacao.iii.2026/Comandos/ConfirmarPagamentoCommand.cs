using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using umfg.venda.app.programacao.iii._2026.Abstracoes;
using umfg.venda.app.programacao.iii._2026.UserControls;
using umfg.venda.app.programacao.iii._2026.ViewModels;

namespace umfg.venda.app.programacao.iii._2026.Comandos;

internal class ConfirmarPagamentoCommand : AbstractCommand
{
    public override void Execute(object? parameter)
    {
        if (!(parameter is ReceberPedidoViewModel vm))
        {
            MessageBox.Show("Erro ao confirmar recebimento pedido!");
            return;
        }

        if (string.IsNullOrWhiteSpace(vm.NumeroCartao))
        {
            MessageBox.Show("Prencha o número do cartão!");
            return;
        }

        if (vm.NumeroCartao.Length < 16)
        {
            MessageBox.Show($"O número do cartão {vm.NumeroCartao} inválido!");
            return;
        }

        if (string.IsNullOrWhiteSpace(vm.CVV))
        {
            MessageBox.Show("Prencha o número do CVV!");
            return;
        }

        if (vm.NumeroCartao.Length < 3)
        {
            MessageBox.Show($"O número do CVV {vm.CVV} inválido!");
            return;
        }

        if (vm.DataValidade < DateTime.Today)
        {
            MessageBox.Show("Data de validade do cartão inválida!");
            return;
        }

        MessageBox.Show("Pedido recebido com sucesso!");
        vm.IsInicio = true;
        vm.Notify();
    }
}

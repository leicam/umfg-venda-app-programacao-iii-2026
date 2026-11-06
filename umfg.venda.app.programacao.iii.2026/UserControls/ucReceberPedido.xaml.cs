using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using umfg.venda.app.programacao.iii._2026.Interfaces;
using umfg.venda.app.programacao.iii._2026.Modelos;
using umfg.venda.app.programacao.iii._2026.ViewModels;

namespace umfg.venda.app.programacao.iii._2026.UserControls;

/// <summary>
/// Interação lógica para ucReceberPedido.xam
/// </summary>
public partial class ucReceberPedido : UserControl
{
    private DatePicker? _datePickerAberto = null;

    private ucReceberPedido(IObserver observer, PedidoModel pedido)
    {
        InitializeComponent();
        DataContext = new ReceberPedidoViewModel(this, observer, pedido);
    }

    internal static void Show(IObserver observer, PedidoModel pedido)
        => (new ucReceberPedido(observer, pedido).DataContext as ReceberPedidoViewModel).Notify();

    private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        var regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }

    private void DatePicker_CalendarOpened(object sender, RoutedEventArgs e)
    {
        _datePickerAberto = sender as DatePicker;

        if (_datePickerAberto is null)
            return;

        var popup = _datePickerAberto.Template
            .FindName("PART_Popup", _datePickerAberto) as Popup;

        if (popup is not null && popup.Child is Calendar calendario)
        {
            calendario.DisplayMode = CalendarMode.Decade;
            calendario.DisplayDateChanged -= CalendarDisplayMode;
            calendario.DisplayDateChanged += CalendarDisplayMode;
        }
    }

    private void CalendarDisplayMode(object? sender, CalendarDateChangedEventArgs e)
    {
        var calendario = sender as Calendar;

        if (calendario is null)
            return;

        if (calendario.DisplayMode != CalendarMode.Year)
            return;

        calendario.SelectedDate = calendario.DisplayDate;

        if (_datePickerAberto != null)
            _datePickerAberto.IsDropDownOpen = false;
    }
}
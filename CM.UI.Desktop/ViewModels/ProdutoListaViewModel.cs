﻿using CM.UI.Desktop.ViewModels.Base;
using CM.UI.Model.Models;
using PropertyChanged;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ProdutoListaViewModel : ListaViewModelBase<ProdutoModel>
    {
        public string FiltroNome
        {
            set { ListaRegistros.Filter = m => ((ProdutoModel)m).Nome.Contains(value); }
        }
    }
}

using System;
using Windows.Foundation.Metadata;
using Windows.Phone.UI.Input;
using Caliburn.Micro;

namespace Ignite.Features.ViewModels
{
    public class DetectionViewModel : Screen
    {
        public DetectionViewModel()
        {
            AnniversaryContact = ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 3);
            HardwareButtonsPresent = ApiInformation.IsTypePresent(typeof (HardwareButtons).FullName);
        }

        public bool AnniversaryContact { get; }
        public bool HardwareButtonsPresent { get; }
    }
}

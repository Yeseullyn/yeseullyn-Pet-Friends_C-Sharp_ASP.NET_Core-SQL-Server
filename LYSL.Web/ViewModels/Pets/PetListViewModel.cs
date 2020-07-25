using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LYSL.Web.ViewModels.Pet
{
    public class PetListViewModel
    {
        public IEnumerable<PetViewModel> PetViewList { get; set; }
    }
}

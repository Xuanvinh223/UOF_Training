using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Training.Acceptance.PO;
using Training.Data;
using System.Xml.Linq;

namespace Training.UCO.Acceptance
{
    public class AcceptanceUCO
    {
        Training_AcceptancePO AcceptancePO = new Training_AcceptancePO();


        public DataTable GetData(string RKNO)
        {
            return AcceptancePO.GetData(RKNO);
        }
    }
}

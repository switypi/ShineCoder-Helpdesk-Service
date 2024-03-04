using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineCoder_Helpdesk.Core.Enums
{
	public enum RoleClaimEnum
	{
		NEWLIST=0,
		OPENLIST=1,
		COMPLETEDLIST=2,
		RESOLVEDLIST=3,
		OVERDUELIST=4,
		DUETODAYLIST = 5,
		MASTERDATA = 6,
		APPSETTING = 7,
        USERMANAGEMENT=8

	}
    public enum UserClaimEnum
    {
        FULLACCESS = 0,
        VIEWACCESS = 1,
        EDITACCESS = 2,
        ADDACCESS = 3,
        DELETEACCESS = 4,
        PRINTACCESS = 5,
        EXPORTACCESS = 6,
        UPDATETICKETSTATUS = 7
    }
}

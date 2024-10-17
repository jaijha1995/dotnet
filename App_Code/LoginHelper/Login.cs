using System;

namespace Core.InterfaceLayer
{
	/// <summary>
	/// Summary description for Login.
	/// </summary>
	public class Login
	{		
		#region --All private variable--
		private string sUserID;
		private string sPWD;
		private string sURL;  //add by ankit
		private string sUserName;
		private bool bCheckStatus;
		private string right_codes;
		private string sEmail;
		private string ipAddress;
		private string textPassword;
		private string sPWDUnEncrypted;
		private string sOldPWD;
        private int emailCount;
        private int commentCount;
        private string extendedUserType;

        private string companyId;
        private int staffId;
        private string phone;
        private int branchId;

        private string fname;
        private string profileimg;

		#endregion

		#region --To create all the properties--
		// To set UserID for Login page
		public string UserID
		{
			get
			{
				return sUserID;
				
			}
			set
			{
				sUserID = value;
			}
		}

		//To get or set the PWD  of user
		public string PWD
		{
			get
			{
				return sPWD;
			}
			set
			{
				sPWD = value;
			}
		}

		public string URL //add by ankit
		{
			get
			{
				return sURL;
			}
			set
			{
				sURL = value;
			}
		}

		//To get status of user validation
		public bool Status
		{
			get
			{
				return bCheckStatus;
			}
			set
			{
				bCheckStatus = value;
			}
		}

		//To get Name of user 
		public string UserName
		{
			get
			{
				return sUserName;
			}
			set
			{
				sUserName = value;
			}
		}
		//To get Type of user 
		public string Right_Codes
		{
			get
			{
                return right_codes;
			}
			set
			{
                right_codes = value;
			}
		}

		// To set Email for Login page
		public string EMail
		{
			get
			{
				return sEmail;
				
			}
			set
			{
				sEmail = value;
			}
		}

		// Get or set text password 21 April 05
		public string TextPassword
		{
			get
			{
				return textPassword;
			}
			set
			{
				textPassword = value;
			}
		}

		// Get or set education 6May05 
		public string IPAddress
		{
			get
			{
				return ipAddress;
			}
			set
			{
				ipAddress = value;
			}
		}
		//To get or set the UnEncrypted PWD  of user
		public string PWDUnEncrypted
		{
			get
			{
				return sPWDUnEncrypted;
			}
			set
			{
				sPWDUnEncrypted = value;
			}
		}
		public string OldPWD
		{
			get
			{
				return sOldPWD;
			}
			set
			{
				sOldPWD = value;
			}
		}
        public int EmailCount
        {
            get { return emailCount; }
            set { emailCount = value; }
        }
        public int CommentCount
        {
            get { return commentCount; }
            set { commentCount = value; }
        }
        public string ExtendedUserType
        {
            get { return extendedUserType; }
            set { extendedUserType = value; }
        }

        public string CompanyId
        {
            get { return companyId; }
            set { companyId = value; }
        }

        public int Staff_Id
        {
            get { return staffId; }
            set { staffId = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public int BranchId
        {
            get { return branchId; }
            set { branchId = value; }
        }

        public string FName
        {
            get { return fname; }
            set { fname = value; }
        }
        public string ProfileImg
        {
            get { return profileimg; }
            set { profileimg = value; }
        }

        public int AgentId { get; set; }

        public string RoleType { get; set; }

		#endregion		
	}
}


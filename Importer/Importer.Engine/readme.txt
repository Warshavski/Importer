TODO :
	Date : 04.08.2015
		1. Add functionality to create tables
			1.1 Add DataType initialization in Column class constructor
			1.2 Add DataType convert to MS Sql DataType (oledb return int values, must be string)
				Convert to .... 
			1.3 Add DataType length parse
		
	Date : 11.08.2015	
		Create following sturcture :
/ - solution root

/[App]Core - project that contains the Model - pure business logic
/[App]Core/Model - data model (lowercase "m"), POCOs
/[App]Core/Daos - data access layer (all interfaces)
/[App]Core/Services - business logic classes (interfaces and implementations)

/[App]Ui - project that contains all UI-related code, but is UI-agnostic
/[App]Ui/Model - contains POCOs that are used by the UI but not the Core
/[App]Ui/Presenters - contains presenters
/[App]Ui/Views - contains view interfaces

/[App][Platform] - project that contains all UI-specific code (e.g. WinRT, WinPhone, WinForms, WPF, Silverlight, etc)
/[App][Platform]/Daos - implementation of DAO interfaces defined in [App]Core
/[App][Platform]/Services - implementation of business logic interfaces defined in [App]Core
/[App][Platform]/Views - implementation of view interfaces defined in [App]Ui
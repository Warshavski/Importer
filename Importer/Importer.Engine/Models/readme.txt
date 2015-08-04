TODO (global) : 
	Add Folders : (moderated)
		1. Common
	
	Separate Storage files and Source files :
		1. Storage files :
			a. List of tables :
				i. List of columns.
				ii. Get table data.
				iii. Import data.
			b. Connection string.
			c. Display name.
			d. Test connection.
			e. File browser.
			f. Extended properties.
		2. Source files :
			a. List of tables :
				i. List of columns.
				ii. Get table data.
			b. Connection string.
			c. Display name.
			d. Test connection.
			e. File browser
			f. Extended properties.
			
			Interface :
				1. Get list of file types (Storage/Source).
				2. Get list of extended properties (Storage/Source).
				3. Get list of tables (Storage/Source).
				4. Get list of columns (Storage/Source).
				5. Get table data (Storage/Source)
				6. Test connection (Storage/Source)
				7. Select columns for import (Storage/Source)
				8. Import data (Storage)
			
			
			Abstract class (Abstract file) :
				1. Get list of file types (better define in Presenter or create static method)
				2. Extended properties - different for each file (Excel, Dbf, Txt, SQL)
					- Abstract method GetProperties();
				3. List of tables - diffrent for Storage/Source classes (Storage include import data for each table in collection)
					- Abstract class Table -> StorageTable (include import data method)
										   -> ??SourceTable?? (full copy of Table class)
				4. List of columns - common class (initialization and properties common for all)
					- Public class Column
				5. Table data - common method for Storage/Source classes (using CommonDataBase class that realize methods for data manipulaton)
					- Public method GetData() in Abstact file class
				6. Test connection - commod method for Storage/Source classes (using CommonDataBase class that realize methods for data manipulaton)
					- Public method TestConnection() in Abstrac file class
				7. Select columns - common for Storage/Source Table classes
					- Public propertie IsSelected in Column class
				8. Import data - only for Storage table class diffrent for each Storage class
					- Abstract method ImportData() for Abstract Storage table class
				
			
21.07.2015 
	TODO : Create normal DataViewer (presenter, form, view, engine)
	
30.07.2015
	TODO : Add the ability to create new tables
		   Add the ability to change the encoding of data in data viewer	
		   
03.08.2015
	TODO : 
		1. Create configuration file.
		2. Replace all connection strings to configuration file.
		3. Rewrite all data base commands with using command constructors (sql injections)
		4. Encript all data base connections.
		5. Delete TODO list.
		6. Initizlize all connection strings by DbConnectionStringBuilder
		7. Add empty table constant in table list initialization function
			and add bool parameter like in table columns list initialization
		
	
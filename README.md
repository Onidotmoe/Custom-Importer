# Custom Importer
Custom Importers for Monogame's Pipeline tool.

## Byte Importer
  Allows you to import any generic file into the pipeline tool and have it end up as a .xna file.

## String Importer
  Defaults to .txt files but can really take any generic text file.
  
## Note
  Both the importers have processors but they don't really do anything, i'll leave it like that incase you or i want to put something inbetween there.
 
You need to add a reference to the .dll like below or include it into your project. Using the menu in the pipeline tool currently causes it to crash for me, adding it manually works fine.


#-------------------------------- References --------------------------------#

/reference:..\..\..\Custom Importer\Custom Importer\bin\Debug\Custom Importer.dll

#---------------------------------- Content ---------------------------------#


You also need to include StringReader & ByteArrayReader into your project, i prefer just referencing the .dll in my main project.

## License
Public Domain + Absorption v1.0

Public Domain :
Custom Importer is in the Public Domain.

Absorption v1.0 :
Any and all changes to this repository is absorbed into the main license; which is the public domain.
Any and all contributions to this repository is absorbed into the main license; which is the public domain.
You are free to copy and do whatever you want with your copy of this repository.

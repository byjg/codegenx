ifndef TARGET
	error You must provide TARGET when making
endif

CSC=gmcs

ifdef RELEASE
CSCFLAGS=/nologo /optimize+ /d:TRACE
else
CSCFLAGS=/nologo /debug+ /d:TRACE,DEBUG
endif

CODEGENX_EXE=$(TARGET)/bin/codegenx.exe
CODEGENX_PDB=$(TARGET)/bin/codegenx.exe
CODEGENX_SRC=CodeGenX/Classes/BaseXML.cs \
	CodeGenX/Classes/ExtraPropertiesXML.cs \
	CodeGenX/Classes/TorqueXML.cs \
	CodeGenX/Classes/XMLValidator.cs \
	CodeGenX/Form1.cs \
	CodeGenX/Form1.Designer.cs \
	CodeGenX/Form2.cs \
	CodeGenX/Form2.Designer.cs \
	CodeGenX/Program.cs \
	CodeGenX/Properties/AssemblyInfo.cs \
	CodeGenX/Classes/Platform.cs

$(CODEGENX_EXE): $(CODEGENX_SRC)
	mkdir -p $(TARGET)/bin
	$(CSC) $(CSCFLAGS) /r:System.dll /r:System.Data.dll /r:System.Drawing.dll /r:System.Windows.Forms.dll /r:System.Xml.dll /target:winexe /out:$(CODEGENX_EXE) $(CODEGENX_SRC)



# common targets

all:	$(CODEGENX_EXE)

clean:
	-rm -f "$(CODEGENX_EXE)" 2> /dev/null
	-rm -f "$(CODEGENX_PDB)" 2> /dev/null


# project names as targets

CodeGenX: $(CODEGENX_EXE)

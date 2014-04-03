CSC=gmcs
RESX=resgen

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

CodeGenX/Form1.resources: CodeGenX/Form1.resx
	$(RESX) /compile $< 

CodeGenX/Form2.resources: CodeGenX/Form2.resx
	$(RESX) /compile $< 

$(CODEGENX_EXE): CodeGenX/Form1.resources CodeGenX/Form2.resources $(CODEGENX_SRC)
	mkdir -p $(TARGET)/bin 
	$(CSC) $(CSCFLAGS) /r:System.dll /r:System.Data.dll /r:System.Drawing.dll /r:System.Windows.Forms.dll /r:System.Xml.dll /target:winexe /res:CodeGenX/Form1.resources,CodeGenx/Form2.resources /out:$(CODEGENX_EXE) $(CODEGENX_SRC)



# common targets

all:	$(CODEGENX_EXE)

clean:
	-rm -f "$(CODEGENX_EXE)" 2> /dev/null
	-rm -f "$(CODEGENX_PDB)" 2> /dev/null


# project names as targets

CodeGenX: $(CODEGENX_EXE)

#
TOPDIR = ..

#
include $(TOPDIR)/make.inc

#
CS_FLAGS += /reference:Office.dll  \
            /reference:Microsoft.Office.Interop.Excel.dll \
            /reference:Microsoft.Office.Interop.Word.dll  \

#
SOURCES = \
    excel_open.cs  \
    excel_start.cs \
    excel_create.cs \
    word_open.cs   \
    excel_report.cs \


TARGETS = $(SOURCES:.cs=.exe)

default : $(TARGETS)

.PHONY : clean
clean:
	$(RM) $(TARGETS) *.txt


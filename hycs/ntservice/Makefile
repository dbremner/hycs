#
TOPDIR = ..

#
include $(TOPDIR)/make.inc

#
CS_FLAGS +=

#
SOURCES = \
    helloService.cs  \
    myservice.cs     \
    serviceUtil.cs   \
    remoteService.cs \
    myservice_test.cs\


TARGETS = $(SOURCES:.cs=.exe)
    
default : $(TARGETS)

.PHONY : clean
clean:
	$(RM) $(TARGETS) *.txt


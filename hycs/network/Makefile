#
TOPDIR = ..

#
include $(TOPDIR)/make.inc

#
CS_FLAGS +=

#
SOURCES = \
    minicrawler.cs \
    ping.cs        \
    ipaddr.cs      \
    webclient.cs   \
    sendmail.cs    \
    webrequest.cs  \
    chat_server.cs \
    chat_client.cs \
    mtsock_server.cs \
    mtsock_client.cs \
    sock_server.cs   \
    sock_client.cs   \
    myTcpListener.cs \
    myTcpClient.cs   \
    mySslTcpListener.cs \
    mySslTcpClient.cs  \
    net_interface.cs   \
    AsyIOServer.cs   \
    AsyIOClient.cs   \


TARGETS = $(SOURCES:.cs=.exe)

default : $(TARGETS)

.PHONY : clean
clean:
	$(RM) $(TARGETS)


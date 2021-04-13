FROM microsoft/mssql-server-linux
COPY ./User/db/data /
RUN chmod +x ./SqlCmdStartup.sh
CMD /bin/bash ./entrypoint.sh
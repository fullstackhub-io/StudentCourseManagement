FROM microsoft/mssql-server-linux
COPY ./Course/db/data /
RUN chmod +x ./SqlCmdStartup.sh
CMD /bin/bash ./entrypoint.sh 
FROM microsoft/mssql-server-linux
COPY ./StudentCourse/db/data /
RUN chmod +x ./SqlCmdStartup.sh
CMD /bin/bash ./entrypoint.sh
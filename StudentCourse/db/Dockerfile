FROM mcr.microsoft.com/mssql/server:2017-CU24-ubuntu-16.04
COPY ./StudentCourse/db/data /
RUN chmod +x ./SqlCmdStartup.sh
CMD /bin/bash ./entrypoint.sh
FROM mcr.microsoft.com/devcontainers/dotnet:1-8.0-bookworm

# [Optional] Uncomment this section to install additional OS packages.
# RUN apt-get update && export DEBIAN_FRONTEND=noninteractive \
#     && apt-get -y install --no-install-recommends <your-package-list-here>

# [Optional] Uncomment this line to install global node packages.
# RUN su vscode -c "source /usr/local/share/nvm/nvm.sh && npm install -g <your-package-here>" 2>&1

# Install PostgreSQL Client
RUN apt-get update && \
    apt-get install -y postgresql-client

EXPOSE 5022
EXPOSE 5432

# Install dotnet tools for vscode user
USER vscode
RUN dotnet tool install -g dotnet-ef
ENV PATH $PATH:/root/.dotnet/tools
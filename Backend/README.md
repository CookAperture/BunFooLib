# The Backend

Here all APIs will find their home.

## Prerequisites

### Docker

* have a maridb container (example cmd)
* have a local nuget server (aka feed) ´´´docker run --detach=true --publish 5000:80 --env NUGET_API_KEY="my-secret" --volume /srv/docker/nuget/database:/var/www/db --volume /srv/docker/nuget/packages:/var/www/packagefiles --name nuget-server sunside/simple-nuget-server´´´ --> https://hub.docker.com/r/sunside/simple-nuget-server/

## Initial Setup

* Build & Publish Shared apis in following order: TODO
* Package Puplish: ´´´nuget push -src http://127.0.0.1:5000/ -ApiKey my-secret C:/Data/UdemyPlayground/BunFooLib/Backend/BunFooLib.Api.Shared/BunFooLib.Api.Shared/bin/Debug/BunFooLib.Api.Shared.Dto.1.0.1.nupkg´´´
* Run cmd in selected api: TODO
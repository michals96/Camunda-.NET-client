## HOW TO RUN

1. Run `docker-compose up -d`
2. Start browser in *NO-CORS* mode

* gchrome on windows it is `chrome.exe --user-data-dir="C://Chrome dev session" --disable-web-security`
* gchrome onlinux it is `google-chrome --disable-web-security`

3. Go to `localhost:3000`

* `docker logs -f container_id` to see backend logs
* `docker-compose down` to stop and remove containers with networks\
* `docker-compose pull` to update images on change
* `docker exec -it container_id /bin/bash` to get into container

![Alt text](./licensing-process.PNG?raw=true "Licensing process")
## REQUESTS

**1. Start process**

URL
`POST - http://localhost:8080/engine-rest/process-definition/key/licensing-process/start`

Body
```
{}
```

**2. Complete user task with no variables**

URL
`http://localhost:8080/engine-rest/task/{id}/complete`

Body
```
{}
```

**3. Complete user task with variables**

URL
`http://localhost:8080/engine-rest/task/{id}/complete`

Body
```
{"variables":
    {"aVariable": {"value": "aStringValue"},
    "anotherVariable": {"value": 42},
    "aThirdVariable": {"value": true}}
}
```

or

```
{"variables":
    {"accepted": {"value": true},
    "rejected": {"value": false},
    "moreDetails": {"value": false}}
}
```

X. Get Activity Instance (no-body)

URL
`GET - http://localhost:8080/engine-rest/process-instance/{id}/activity-instances`



### ABBREVIATIONS

Run browser with disabled CORS mode

`chrome.exe --user-data-dir="C://Chrome dev session" --disable-web-security`

Or disable it by adding below filter in web.xml configuration of engine-rest

```
    <filter>
      <filter-name>CorsFilter</filter-name>
      <filter-class>org.apache.catalina.filters.CorsFilter</filter-class>
      <init-param>
        <param-name>cors.allowed.origins</param-name>
        <param-value>*</param-value>
      </init-param>
      <init-param>
        <param-name>cors.allowed.methods</param-name>
        <param-value>GET,POST,HEAD,OPTIONS,PUT,DELETE</param-value>
      </init-param>
      <init-param>    
            <param-name>cors.allowed.headers</param-name>    
            <param-value>Content-Type,X-Requested-With,accept,Origin,Access-Control-Request-Method,Access-Control-Request-Headers,Authorization</param-value>    
        </init-param>    
        <init-param>    
            <param-name>cors.exposed.headers</param-name>    
            <param-value>Access-Control-Allow-Origin</param-value>      
        </init-param>    
    </filter>
    <filter-mapping>
      <filter-name>CorsFilter</filter-name>
      <url-pattern>/*</url-pattern>
    </filter-mapping>
```
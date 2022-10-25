# REQUESTS

1. Start process

URL
`http://localhost:8080/engine-rest/process-definition/key/licensing-process/start`

Body
```
{}
```



# ABBREVIATIONS

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
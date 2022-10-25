import {Box, Button, TextareaAutosize, TextField} from "@mui/material";
import React, {useState} from "react";
import {postCamundaEngine} from "../services/post-camunda.engine";

import styles from "./request-window.module.scss";

const RequestWindow = (): JSX.Element => {
    const [url, setUrl] = useState<string>('');
    const [body, setBody] = useState<any>();

    const handleUrlChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setUrl(event.target.value);
    };

    const handleBodyChange = (event: React.ChangeEvent<HTMLTextAreaElement>) => {
        setBody(JSON.parse(event.target.value));
    };

    return (<Box
            component="form"
            sx={{
                '& .MuiTextField-root': {m: 1, width: '50ch'},
            }}
            noValidate
            autoComplete="off"
            className={styles.container}
        >
            <TextField size="medium" label="Camunda REST Api URL" id="url_input" onChange={handleUrlChange}/>
            <TextareaAutosize
                maxRows={4}
                aria-label="maximum height"
                placeholder="Request body : Camunda REST Api"
                style={{width: 400, height: 500}}
                onChange={handleBodyChange}
            />
            <Button variant="contained"
                    onClick={() => {
                        postCamundaEngine(url, body).then(r => alert("Success!"));
                    }}>
                Send to Camunda
            </Button>
        </Box>)
}

export default RequestWindow;
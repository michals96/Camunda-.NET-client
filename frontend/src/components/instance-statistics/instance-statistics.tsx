import {Box, Button, Grid} from "@mui/material";
import React, {useState} from "react";
import {getCamundaEngine} from "../../services/get-camunda.engine";
import {ProcessStats} from "../../types/process-stats.types";
import InstanceStatisticsRow from "./instance-statistics-row/instance-statistics-row";
import styles from "./instance-statistics.module.scss";

const InstanceStatistics = (): JSX.Element => {
    const [processStats, setProcessStats] = useState<ProcessStats[]>();

    return (
        <Box
            component="form"
            sx={{
                '& .MuiTextField-root': {width: '40ch'},
            }}
            noValidate
            autoComplete="off"
            className={styles.container}
        >
            <Button variant="contained"
                    style={{width: 500, margin: 30}}
                    onClick={() => {
                        getCamundaEngine().then(r => setProcessStats(r.data));
                    }}>
                Get License process statistics
            </Button>
            <Grid container direction='column' gap={3}>
                {
                    processStats?.map((processStats, index) => (
                        <InstanceStatisticsRow processStats={processStats} key={index}></InstanceStatisticsRow>
                    ))
                }
            </Grid>
        </Box>
    );
}

export default InstanceStatistics;
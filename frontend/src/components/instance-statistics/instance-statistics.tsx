import {Box, Button, Grid} from "@mui/material";
import React, {useState} from "react";
import {getAllUserTasks, getProcessStatistics} from "../../services/get-camunda.engine";
import {ProcessStats} from "../../types/process-stats.types";
import {UserTask} from "../../types/user-task.types";
import InstanceStatisticsRow from "./instance-statistics-row/instance-statistics-row";
import styles from "./instance-statistics.module.scss";

const InstanceStatistics = (): JSX.Element => {
    const [processStats, setProcessStats] = useState<ProcessStats[]>();
    const [userTasks, setUserTasks] = useState<UserTask[]>();

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
                        getProcessStatistics().then(r => setProcessStats(r.data));
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

            {/*  USER TASKS SECTION  */}
            <Button variant="contained"
                    style={{width: 500, margin: 30}}
                    onClick={() => {
                        getAllUserTasks().then(r => setUserTasks(r.data));
                    }}>
                Refresh UserTask List
            </Button>
            <Grid container direction='column' gap={3}>
                <div className={styles.userTaskRow}>
                {
                    userTasks?.map((userTask, index) => (
                        <p>Task: <strong>{userTask.name}</strong>
                            <br/>
                            Task ID: <strong>{userTask.id}</strong>
                            <br/>
                            Process Instance ID: <strong>{userTask.processInstanceId}</strong>
                        </p>
                    ))
                }
                </div>
            </Grid>
        </Box>
    );
}

export default InstanceStatistics;
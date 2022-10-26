import {ProcessStats} from "../../../types/process-stats.types";
import {Chip} from "@mui/material";

interface Props {
    processStats: ProcessStats;
}

const InstanceStatisticsRow = ({processStats}: Props): JSX.Element => {
    return (
        <div>
            <Chip label={<b>STATUS:</b>} color='info' style={{margin: 5}}></Chip>
            <Chip label={processStats.id}></Chip>
            <Chip label={<b>INSTANCES:</b>} color='info' style={{margin: 5}}></Chip>
            <Chip label={processStats.instances}></Chip>
        </div>
    );
}

export default InstanceStatisticsRow;
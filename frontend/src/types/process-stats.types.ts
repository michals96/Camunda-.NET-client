export interface ProcessStats {
    class: string;
    id: string;
    instances: number;
    failedJobs: number;
    incidents: any[];
}
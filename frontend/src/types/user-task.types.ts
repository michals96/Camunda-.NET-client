export interface UserTask {
    id: string;
    name: string;
    assignee: string;
    created: Date;
    due: Date;
    followUp: Date;
    delegationState: string;
    description: string;
    executionId: string;
    owner: string;
    parentTaskId: string;
    priority: number;
    processDefinitionId: string;
    processInstanceId: string;
    caseDefinitionId: string;
    caseInstanceId: string;
    caseExecutionId: string;
    taskDefinitionKey: string;
    formKey: string;
    tenantId: string;
}
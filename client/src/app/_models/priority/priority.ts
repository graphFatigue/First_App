export enum Priority {
    High = "High",
    Medium = "Medium",
    Low = "Low"
  }

  export const PriorityLabelMapping: Record<Priority, string> = {
    [Priority.High]: "High",
    [Priority.Medium]: "Medium",
    [Priority.Low]: "Low",
};
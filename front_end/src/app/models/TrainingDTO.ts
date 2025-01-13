export interface TrainingDTO {
  id: number,
  duration: number,
  caloriesBurned: number,
  trainingDifficulty: number,
  tiredness: number,
  notes?: string,
  trainingDate: Date,
}

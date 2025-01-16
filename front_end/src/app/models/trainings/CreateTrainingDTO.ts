export interface CreateTrainingDTO {
  duration: number,
  caloriesBurned: number,
  trainingDifficulty: number,
  tiredness: number,
  notes?: string,
  trainingTypeId: number,
  year: number,
  month: number,
  day: number,
  gymMemberId: number
}

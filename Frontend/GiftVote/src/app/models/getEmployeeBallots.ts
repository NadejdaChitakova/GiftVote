export interface EmployeeBallot{
  id: number,
  giftReceiverId: number,
  giftReceiverName: string,
  isUserVote : boolean,
  isCurrentUserCanStopBallot: boolean,
  startTime: any,
  endTime: any,
}

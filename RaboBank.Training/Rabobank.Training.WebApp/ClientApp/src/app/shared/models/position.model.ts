import { MandateVM } from "./mandate.model";

export interface PositionVM {
  code: string;
  name: string;
  value: number;
  mandates: MandateVM[];
}

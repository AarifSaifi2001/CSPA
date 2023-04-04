import { Icar } from "./Icar";
import { Photo } from "./photos";

export class Car implements Icar{
  id: number;
  name: string;
  price: number;
  image?: string;
  sellRent: number;
  km: number;
  citiesId: number;
  location: string;
  modelyear: number;
  fueltypeId: number;
  fueltype: string;
  carbrand: string;
  bodytypeId: number;
  btype: string;
  owner: number;
  state: string;
  address: string;
  landmark: string;
  cardesc: string;
  postedon: Date;
  postedBy: number;
  photos?: Photo[];
}

using System.Threading.Tasks;

namespace SampleClientApp
{
    public class BuildingScenario
    {
        private readonly CommandLoop cl;
        public BuildingScenario(CommandLoop cl)
        {
            this.cl = cl;
        }

        public async Task InitBuilding()
        {
            // Log.Alert($"Deleting all twins...");
            // await cl.DeleteAllTwinsAsync();
            Log.Out($"Creating 1 floor, 1 room and 1 thermostat...");
            await InitializeGraph();
        }

        private async Task InitializeGraph()
        {
            await cl.CommandCreateDigitalTwin(new string[24]
                {
                    "CreateTwin", "dtmi:digitaltwins:rec_3_3:building:ShoppingMall;1", "1090",
                    "temperature", "metadata", "",
                    "area", "metadata", "grossArea,double,1834538,usableArea,double,1834538,rentableArea,double,1834538",
                    "capacity", "metadata", "",
                    "occupancy", "metadata", "",
                    "humidity", "metadata", "",
                    "CO2", "metadata", "",
                    "name", "string", "Yorkdale Shopping Centre"
                });
            await cl.CommandCreateDigitalTwin(new string[6]
                {
                    "CreateTwin", "dtmi:digitaltwins:rec_3_3:building:Floor;1", "1090-lower-level",
                    "name", "string", "Yorkdale Lower Level"
                });
            await cl.CommandCreateDigitalTwin(new string[6]
                {
                    "CreateTwin", "dtmi:digitaltwins:rec_3_3:building:Floor;1", "1090-ground-level",
                    "name", "string", "Yorkdale Ground Level"
                });
            await cl.CommandCreateDigitalTwin(new string[6]
                {
                    "CreateTwin", "dtmi:digitaltwins:rec_3_3:building:Floor;1", "1090-upper-level",
                    "name", "string", "Yorkdale Upper Level"
                });
            await cl.CommandCreateDigitalTwin(new string[6]
                {
                    "CreateTwin", "dtmi:digitaltwins:rec_3_3:agents:Department;1", "57151",
                    "name", "string", "Yorkdale Shopping Centre"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "1090-lower-level", "componentOfBuilding", "1090", "floor_to_building",
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "1090-ground-level", "componentOfBuilding", "1090", "floor_to_building",
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "1090-upper-level", "componentOfBuilding", "1090", "floor_to_building",
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "57151", "owns", "1090", "agent_to_building",
                });
            object[,] data = {{"0005","773"},{"0006A","2970"},{"0006B","2563"},{"0009","2513"},{"0010","2438"},{"0011","2432"},{"0012","1905"},{"0012A","3354"},{"0012C","3797"},{"0012CM","2917"},{"0012D","8348"},{"0012F","14131"},{"0014A","895"},{"0021","3648"},{"22","1474"},{"0022A","1075"},{"26","14109"},{"0028A","10494"},{"0028C","8674"},{"0029A","947"},{"0029B","936"},{"30","10854"},{"0032A","737"},{"0032B","457"},{"0032C","212"},{"0032D","16"},{"0033A","3671"},{"34","10201"},{"0034A","264"},{"42","10768"},{"44","8432"},{"46","3327"},{"48","4808"},{"49","1609"},{"51","6685"},{"53","4565"},{"54","3100"},{"55","3110"},{"56","1950"},{"57","4272"},{"58","4692"},{"60","4709"},{"61","2245"},{"64","1831"},{"65","1340"},{"66","1296"},{"67","1361"},{"68","1793"},{"71","4960"},{"72","1621"},{"74","719"},{"75","713"},{"76","2699"},{"0077A","1529"},{"80","3608"},{"81","816"},{"82","1352"},{"83","1565"},{"84","3539"},{"86","4680"},{"87","5270"},{"90","1837"},{"91","2295"},{"92","1257"},{"0093A","805"},{"94","1760"},{"95","1990"},{"97","861"},{"98","1913"},{"110","800"},{"0111A","4349"},{"113","3254"},{"115","3326"},{"116","2232"},{"0116A","1662"},{"117","2987"},{"118","1421"},{"120","384"},{"122","638"},{"126","510"},{"128","777"},{"133","762"},{"134","727"},{"135","475"},{"136","1221"},{"137","4175"},{"139","5809"},{"141","2509"},{"0142A","2526"},{"0142B","2251"},{"143","6085"},{"158","5776"},{"159","2869"},{"160","2820"},{"161","3829"},{"0161B","3496"},{"0163A1","1932"},{"0163B1","2250"},{"168","1397"},{"169","1942"},{"171","1495"},{"172","2565"},{"0176A","2007"},{"177","1450"},{"180","1140"},{"0181E","1096"},{"0182E","1240"},{"0183E","1212"},{"0184E","434"},{"0185E","1198"},{"0186E","3469"},{"0187E","6459"},{"0188E","1000"},{"189","2410"},{"190","3178"},{"191","861"},{"193","6901"},{"216","3632"},{"0216A","1198"},{"217","1799"},{"219","2980"},{"0220A","2147"},{"0220B","783"},{"221","7165"},{"0224A","1175"},{"0224B","1162"},{"225","1429"},{"0226A","1013"},{"0226B","785"},{"227","698"},{"228","5145"},{"230","4498"},{"231","4383"},{"233","9157"},{"238","2160"},{"239","2089"},{"240","3805"},{"0241A","1795"},{"0242A","4605"},{"243","6144"},{"0245A","985"},{"0245AE","199"},{"246","1155"},{"0246A","601"},{"247","1905"},{"301","1305"},{"302","1741"},{"0303A","1073"},{"0303B","1083"},{"0304A","4607"},{"0305A","960"},{"0305C","6844"},{"0307-1","6663"},{"0307A","3617"},{"308","10079"},{"312","4825"},{"313","4668"},{"314","4668"},{"315","4668"},{"316","3481"},{"317","4196"},{"318","5500"},{"319","4322"},{"0319A","1689"},{"320","2495"},{"321","1605"},{"0321A","1923"},{"322","2500"},{"323","1825"},{"324","1818"},{"325","4614"},{"0401E","1667"},{"0402E","587"},{"0403E","608"},{"404","1997"},{"0404A","602"},{"405","2689"},{"0405B","1363"},{"407","1081"},{"501","6611"},{"504","1836"},{"505","3673"},{"506","5059"},{"507","2849"},{"508","3345"},{"510","2708"},{"511","2802"},{"512","4672"},{"513","646"},{"514","1417"},{"515","1039"},{"516","1998"},{"517","2601"},{"0517A","450"},{"518","1550"},{"519","2003"},{"520","1617"},{"521","1580"},{"522","2039"},{"523","2435"},{"524","2435"},{"0525A","1271"},{"0525B","610"},{"0527A","593"},{"0527B","1153"},{"529","6389"},{"530","4902"},{"532","2436"},{"533","2882"},{"534","1826"},{"535","2817"},{"0601A","10251"},{"0601B","2297"},{"0601C","3035"},{"602","2255"},{"603","440"},{"604","392"},{"606","2066"},{"607","2125"},{"609","1851"},{"0612A","5126"},{"0612A-2","35"},{"0612B","714"},{"0612B-2","4447"},{"613","2171"},{"614","2906"},{"615","1203"}};
            // object[,] data = {{"0005","773"}};
            Log.Out(data.Length.ToString());
            for (int i = 0; i < data.Length/2; i++)
            {
                // Log.Out("HERE");
                string area = (string)data[i,1];
                string areaString = $"grossArea,double,{area},usableArea,double,{area},rentableArea,double,{area}";
                // Log.Out(areaString);
                string[] digitalTwin = 
                {
                        "CreateTwin", "dtmi:digitaltwins:rec_3_3:building:RetailRoom;1", data[i, 0].ToString(),
                        "temperature", "metadata", "",
                        "area", "metadata", areaString.ToString(),
                        "capacity", "metadata", "",
                        "occupancy", "metadata", "",
                        "humidity", "metadata", "",
                        "CO2", "metadata", "",
                        "name", "string", data[i, 0].ToString()
                };
                await cl.CommandCreateDigitalTwin(digitalTwin);
                await cl.CommandCreateRelationship(new string[5]
                    {
                        "CreateEdge", data[i, 0].ToString(), "isPartOf", "1090", "building_to_retail_space",
                    });
                // await cl.CommandCreateRelationship(new string[5]
                //     {
                //         "CreateEdge", data[i, 0].ToString(), "isLocationOf", "1090-ground-level", "floor_to_retail_space",
                //     });
            }
            // await cl.CommandCreateRelationship(new string[11]
            //     {
            //         "CreateEdge", "room21", "contains", "thermostat67", "room_to_therm_edge",
            //         "ownershipUser", "string", "Contoso",
            //         "ownershipDepartment", "string", "Comms Division"
            //     });
        }
    }
}

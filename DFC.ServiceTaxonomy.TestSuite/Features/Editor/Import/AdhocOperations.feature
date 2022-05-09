@webtest
Feature: AdhocOperations
	
Background:
	Given I logon to the editor

Scenario Outline: Order related skills 
	And I Navigate to "/Admin/Contents/ContentItems" 
	And I search under JobProfile using Title text <Job profile>
	And I click on the link with text <Job profile>
	And I switch to the What it takes tab
	And I obtain the expected Related skills order from file "JobProfileSkills"
	When I compare that with the Related skills ordering in the UI
	Then the order is the same
	But if it is not then I rearrange them to be the same
	And I Save and Publish after entering a comment for this <Job profile> Related skills order task

Examples:
	| no. | SOC Code | Job profile                                                   |
	| 1   | 3122D    | 3D printing technician                                        |
	| 2   | 6144A    | Accommodation warden                                          |
	| 3   | 3537A    | Accounting technician                                         |
	| 4   | 2129A    | Acoustics consultant                                          |
	| 5   | 3413B    | Actor                                                         |
	| 6   | 2425A    | Actuary                                                       |
	| 7   | 2229C    | Acupuncturist                                                 |
	| 8   | 4159B    | Admin assistant                                               |
	| 9   | 3543B    | Advertising account executive                                 |
	| 10  | 3543J    | Advertising account planner                                   |
	| 11  | 2473A    | Advertising art director                                      |
	| 12  | 3543C    | Advertising copywriter                                        |
	| 13  | 3541A    | Advertising media buyer                                       |
	| 14  | 3543D    | Advertising media planner                                     |
	| 15  | 2122B    | Aerospace engineer                                            |
	| 16  | 3113A    | Aerospace engineering technician                              |
	| 17  | 5111A    | Agricultural contractor                                       |
	| 18  | 2129B    | Agricultural engineer                                         |
	| 19  | 3113B    | Agricultural engineering technician                           |
	| 20  | 3565A    | Agricultural inspector                                        |
	| 21  | 2112O    | Agronomist                                                    |
	| 22  | 3239J    | Aid worker                                                    |
	| 23  | 3565F    | Air accident investigator                                     |
	| 24  | 3511A    | Air traffic controller                                        |
	| 25  | 6214B    | Airline customer service agent                                |
	| 26  | 3512A    | Airline pilot                                                 |
	| 27  | 8233A    | Airport baggage handler                                       |
	| 28  | 6214C    | Airport information assistant                                 |
	| 29  | 6142A    | Ambulance care assistant                                      |
	| 30  | 2211C    | Anaesthetist                                                  |
	| 31  | 3218B    | Anatomical pathology technician                               |
	| 32  | 6139B    | Animal care worker                                            |
	| 33  | 6139C    | Animal technician                                             |
	| 34  | 3411A    | Animator                                                      |
	| 35  | 1254A    | Antique dealer                                                |
	| 36  | 2135D    | App developer                                                 |
	| 37  | 5119A    | Arboricultural officer                                        |
	| 38  | 2114A    | Archaeologist                                                 |
	| 39  | 2431A    | Architect                                                     |
	| 40  | 3121A    | Architectural technician                                      |
	| 41  | 2435A    | Architectural technologist                                    |
	| 42  | 2452A    | Archivist                                                     |
	| 43  | 1171A    | Army officer                                                  |
	| 44  | 3219A    | Aromatherapist                                                |
	| 45  | 2471A    | Art editor                                                    |
	| 46  | 2229D    | Art therapist                                                 |
	| 47  | 3531A    | Art valuer                                                    |
	| 48  | 2429D    | Arts administrator                                            |
	| 49  | 6139D    | Assistance dog trainer                                        |
	| 50  | 3319B    | Assistant immigration officer                                 |
	| 51  | 2113A    | Astronaut                                                     |
	| 52  | 2113B    | Astronomer                                                    |
	| 53  | 3441E    | Athlete                                                       |
	| 54  | 2219A    | Audiologist                                                   |
	| 55  | 3417D    | Audio-visual technician                                       |
	| 56  | 2421A    | Auditor                                                       |
	| 57  | 5231B    | Auto electrician                                              |
	| 58  | 2122C    | Automotive engineer                                           |
	| 59  | 9249A    | Bailiff                                                       |
	| 60  | 5432A    | Baker                                                         |
	| 61  | 1150A    | Bank manager                                                  |
	| 62  | 4123A    | Banking customer service adviser                              |
	| 63  | 9274A    | Bar person                                                    |
	| 64  | 6221B    | Barber                                                        |
	| 65  | 9272C    | Barista                                                       |
	| 66  | 2412A    | Barrister                                                     |
	| 67  | 3520A    | Barristers' clerk                                             |
	| 68  | 6222A    | Beauty consultant                                             |
	| 69  | 6222B    | Beauty therapist                                              |
	| 70  | 5119B    | Beekeeper                                                     |
	| 71  | 3543E    | Bid writer                                                    |
	| 72  | 4215B    | Bilingual secretary                                           |
	| 73  | 9235A    | Bin worker                                                    |
	| 74  | 2112B    | Biochemist                                                    |
	| 75  | 2112C    | Biologist                                                     |
	| 76  | 2112D    | Biomedical scientist                                          |
	| 77  | 2112E    | Biotechnologist                                               |
	| 78  | 5211A    | Blacksmith                                                    |
	| 79  | 5236A    | Boat builder                                                  |
	| 80  | 9241B    | Bodyguard                                                     |
	| 81  | 5423A    | Bookbinder                                                    |
	| 82  | 4122A    | Bookkeeper                                                    |
	| 83  | 6211A    | Bookmaker                                                     |
	| 84  | 7111A    | Bookseller                                                    |
	| 85  | 3319A    | Border Force officer                                          |
	| 86  | 9134A    | Bottler                                                       |
	| 87  | 5312A    | Bricklayer                                                    |
	| 88  | 3412B    | British Sign Language interpreter                             |
	| 89  | 2316B    | British Sign Language teacher                                 |
	| 90  | 2124A    | Broadcast engineer                                            |
	| 91  | 2471B    | Broadcast journalist                                          |
	| 92  | 1254B    | Builders' merchant                                            |
	| 93  | 3565B    | Building control officer                                      |
	| 94  | 2122D    | Building services engineer                                    |
	| 95  | 2436A    | Building site inspector                                       |
	| 96  | 2434A    | Building surveyor                                             |
	| 97  | 3114A    | Building technician                                           |
	| 98  | 8213A    | Bus or coach driver                                           |
	| 99  | 2423A    | Business adviser                                              |
	| 100 | 2423B    | Business analyst                                              |
	| 101 | 3545B    | Business development manager                                  |
	| 102 | 2424A    | Business project manager                                      |
	| 103 | 5431A    | Butcher                                                       |
	| 104 | 6240A    | Butler                                                        |
	| 105 | 6214A    | Cabin crew                                                    |
	| 106 | 3122A    | CAD technician                                                |
	| 107 | 5432B    | Cake decorator                                                |
	| 108 | 7211A    | Call centre operator                                          |
	| 109 | 8132A    | Car manufacturing worker                                      |
	| 110 | 7129A    | Car rental agent                                              |
	| 111 | 9236A    | Car valet                                                     |
	| 112 | 6147A    | Care escort                                                   |
	| 113 | 3239D    | Care home advocate                                            |
	| 114 | 1242A    | Care home manager                                             |
	| 115 | 6145A    | Care worker                                                   |
	| 116 | 3564A    | Careers adviser                                               |
	| 117 | 6232A    | Caretaker                                                     |
	| 118 | 5315A    | Carpenter                                                     |
	| 119 | 5322A    | Carpet fitter and floor layer                                 |
	| 120 | 3122B    | Cartographer                                                  |
	| 121 | 5436A    | Catering manager                                              |
	| 122 | 8149A    | Cavity insulation installer                                   |
	| 123 | 8149B    | Ceiling fixer                                                 |
	| 124 | 3239I    | Celebrant                                                     |
	| 125 | 5223A    | Cellar technician                                             |
	| 126 | 6148B    | Cemetery worker                                               |
	| 127 | 3422B    | Ceramics designer-maker                                       |
	| 128 | 1139A    | Charity director                                              |
	| 129 | 3543K    | Charity fundraiser                                            |
	| 130 | 8214B    | Chauffeur                                                     |
	| 131 | 5434A    | Chef                                                          |
	| 132 | 2127A    | Chemical engineer                                             |
	| 133 | 3113C    | Chemical engineering technician                               |
	| 134 | 8114A    | Chemical plant process operator                               |
	| 135 | 2111A    | Chemist                                                       |
	| 136 | 1115A    | Chief executive                                               |
	| 137 | 1172A    | Chief inspector                                               |
	| 138 | 3233D    | Child protection officer                                      |
	| 139 | 6122A    | Childminder                                                   |
	| 140 | 2231A    | Children's nurse                                              |
	| 141 | 9239A    | Chimney sweep                                                 |
	| 142 | 2229E    | Chiropractor                                                  |
	| 143 | 3414A    | Choreographer                                                 |
	| 144 | 9275A    | Cinema or theatre attendant                                   |
	| 145 | 9242A    | Civil enforcement officer                                     |
	| 146 | 2121A    | Civil engineer                                                |
	| 147 | 3114B    | Civil engineering technician                                  |
	| 148 | 4112B    | Civil Service administrative officer                          |
	| 149 | 4112C    | Civil Service executive officer                               |
	| 150 | 3561G    | Civil Service manager                                         |
	| 151 | 9233A    | Cleaner                                                       |
	| 152 | 2113J    | Climate scientist                                             |
	| 153 | 2126A    | Clinical engineer                                             |
	| 154 | 2212B    | Clinical psychologist                                         |
	| 155 | 2112G    | Clinical scientist                                            |
	| 156 | 5221A    | CNC machinist                                                 |
	| 157 | 3319C    | Coastguard                                                    |
	| 158 | 2229F    | Cognitive behavioural therapist                               |
	| 159 | 3531B    | Commercial energy assessor                                    |
	| 160 | 2471C    | Commissioning editor                                          |
	| 161 | 3412C    | Communication support worker                                  |
	| 162 | 3231B    | Community arts worker                                         |
	| 163 | 3231C    | Community development worker                                  |
	| 164 | 3231D    | Community education co-ordinator                              |
	| 165 | 2231D    | Community matron                                              |
	| 166 | 8213B    | Community transport driver                                    |
	| 167 | 1131A    | Company secretary                                             |
	| 168 | 2136A    | Computer games developer                                      |
	| 169 | 3131A    | Computer games tester                                         |
	| 170 | 2141A    | Conservator                                                   |
	| 171 | 2436C    | Construction contracts manager                                |
	| 172 | 8149C    | Construction labourer                                         |
	| 173 | 1122A    | Construction manager                                          |
	| 174 | 7129C    | Construction plant hire adviser                               |
	| 175 | 5223B    | Construction plant mechanic                                   |
	| 176 | 8229A    | Construction plant operator                                   |
	| 177 | 5330A    | Construction site supervisor                                  |
	| 178 | 2119A    | Consumer scientist                                            |
	| 179 | 2471D    | Copy editor                                                   |
	| 180 | 2412B    | Coroner                                                       |
	| 181 | 2142B    | Corporate responsibility and sustainability practitioner      |
	| 182 | 2211H    | Cosmetic surgeon                                              |
	| 183 | 3422C    | Costume designer                                              |
	| 184 | 3235A    | Counsellor                                                    |
	| 185 | 9272A    | Counter service assistant                                     |
	| 186 | 2141B    | Countryside officer                                           |
	| 187 | 3550A    | Countryside ranger                                            |
	| 188 | 4112A    | Court administrative assistant                                |
	| 189 | 2419A    | Court legal adviser                                           |
	| 190 | 9249B    | Court usher                                                   |
	| 191 | 8221A    | Crane driver                                                  |
	| 192 | 4121A    | Credit controller                                             |
	| 193 | 3538A    | Credit manager                                                |
	| 194 | 6148C    | Crematorium technician                                        |
	| 195 | 2114B    | Criminologist                                                 |
	| 196 | 3219F    | Critical care technologist                                    |
	| 197 | 2412C    | Crown prosecutor                                              |
	| 198 | 6219B    | Cruise ship steward                                           |
	| 199 | 7219A    | Customer service assistant                                    |
	| 200 | 1259A    | Customer services manager                                     |
	| 201 | 2139A    | Cyber intelligence officer                                    |
	| 202 | 5223C    | Cycle mechanic                                                |
	| 203 | 3442B    | Cycling coach                                                 |
	| 204 | 2229H    | Dance movement psychotherapist                                |
	| 205 | 2312B    | Dance teacher                                                 |
	| 206 | 3414B    | Dancer                                                        |
	| 207 | 2425B    | Data analyst-statistician                                     |
	| 208 | 4217A    | Data entry clerk                                              |
	| 209 | 2425H    | Data scientist                                                |
	| 210 | 3131B    | Database administrator                                        |
	| 211 | 8212B    | Delivery van driver                                           |
	| 212 | 8149D    | Demolition operative                                          |
	| 213 | 3218A    | Dental hygienist                                              |
	| 214 | 6143A    | Dental nurse                                                  |
	| 215 | 3218C    | Dental technician                                             |
	| 216 | 3218D    | Dental therapist                                              |
	| 217 | 2215A    | Dentist                                                       |
	| 218 | 2126B    | Design and development engineer                               |
	| 219 | 2219B    | Dietitian                                                     |
	| 220 | 2134A    | Digital delivery manager                                      |
	| 221 | 2133A    | Digital product owner                                         |
	| 222 | 3561A    | Diplomatic Service officer                                    |
	| 223 | 3417F    | Director of photography                                       |
	| 224 | 3216A    | Dispensing optician                                           |
	| 225 | 2231E    | District nurse                                                |
	| 226 | 5319A    | Diver                                                         |
	| 227 | 3413D    | DJ                                                            |
	| 228 | 6139E    | Dog groomer                                                   |
	| 229 | 6139F    | Dog handler                                                   |
	| 230 | 5241B    | Domestic appliance service engineer                           |
	| 231 | 3531C    | Domestic energy assessor                                      |
	| 232 | 9249C    | Door supervisor                                               |
	| 233 | 2229I    | Dramatherapist                                                |
	| 234 | 5414B    | Dressmaker                                                    |
	| 235 | 8215A    | Driving instructor                                            |
	| 236 | 3417A    | Drone pilot                                                   |
	| 237 | 9234B    | Dry cleaner                                                   |
	| 238 | 8149E    | Dry liner                                                     |
	| 239 | 2315B    | Early years teacher                                           |
	| 240 | 2141C    | Ecologist                                                     |
	| 241 | 3545E    | E-commerce manager                                            |
	| 242 | 2425C    | Economic development officer                                  |
	| 243 | 2425D    | Economist                                                     |
	| 244 | 3412D    | Editorial assistant                                           |
	| 245 | 3119A    | Education technician                                          |
	| 246 | 3233A    | Education welfare officer                                     |
	| 247 | 2137F    | E-learning developer                                          |
	| 248 | 2123A    | Electrical engineer                                           |
	| 249 | 3113D    | Electrical engineering technician                             |
	| 250 | 5241A    | Electrician                                                   |
	| 251 | 5241C    | Electricity distribution worker                               |
	| 252 | 8124A    | Electricity generation worker                                 |
	| 253 | 2124B    | Electronics engineer                                          |
	| 254 | 3112A    | Electronics engineering technician                            |
	| 255 | 6148D    | Embalmer                                                      |
	| 256 | 6141B    | Emergency care assistant                                      |
	| 257 | 7214A    | Emergency medical dispatcher                                  |
	| 258 | 2123B    | Energy engineer                                               |
	| 259 | 5223D    | Engineering construction craftworker                          |
	| 260 | 3113E    | Engineering construction technician                           |
	| 261 | 5223E    | Engineering craft machinist                                   |
	| 262 | 3113F    | Engineering maintenance technician                            |
	| 263 | 8149F    | Engineering operative                                         |
	| 264 | 2319A    | English as a foreign language (EFL) teacher                   |
	| 265 | 3413E    | Entertainer                                                   |
	| 266 | 2142A    | Environmental consultant                                      |
	| 267 | 2463A    | Environmental health officer                                  |
	| 268 | 3562A    | Equalities officer                                            |
	| 269 | 2126C    | Ergonomist                                                    |
	| 270 | 3544A    | Estate agent                                                  |
	| 271 | 1251A    | Estates officer                                               |
	| 272 | 3531D    | Estimator                                                     |
	| 273 | 3546A    | Events manager                                                |
	| 274 | 3421B    | Exhibition designer                                           |
	| 275 | 1251B    | Facilities manager                                            |
	| 276 | 2449A    | Family mediator                                               |
	| 277 | 3231A    | Family support worker                                         |
	| 278 | 4215C    | Farm secretary                                                |
	| 279 | 9111A    | Farm worker                                                   |
	| 280 | 1121A    | Farmer                                                        |
	| 281 | 5211B    | Farrier                                                       |
	| 282 | 3422D    | Fashion design assistant                                      |
	| 283 | 3422E    | Fashion designer                                              |
	| 284 | 3413F    | Fashion model                                                 |
	| 285 | 5319B    | Fence installer                                               |
	| 286 | 2471I    | Film critic                                                   |
	| 287 | 4124A    | Finance officer                                               |
	| 288 | 3534A    | Financial adviser                                             |
	| 289 | 4123B    | Financial services customer adviser                           |
	| 290 | 3411B    | Fine artist                                                   |
	| 291 | 3312B    | Fingerprint officer                                           |
	| 292 | 3313B    | Fire safety engineer                                          |
	| 293 | 3313A    | Firefighter                                                   |
	| 294 | 5111B    | Fish farmer                                                   |
	| 295 | 9119A    | Fishing boat deckhand                                         |
	| 296 | 5119C    | Fishing vessel skipper                                        |
	| 297 | 5433A    | Fishmonger                                                    |
	| 298 | 3443B    | Fitness instructor                                            |
	| 299 | 5443A    | Florist                                                       |
	| 300 | 8111C    | Food factory worker                                           |
	| 301 | 8133A    | Food manufacturing inspector                                  |
	| 302 | 9134B    | Food packaging operative                                      |
	| 303 | 2129D    | Food scientist                                                |
	| 304 | 3442C    | Football coach                                                |
	| 305 | 3442D    | Football referee                                              |
	| 306 | 3422F    | Footwear designer                                             |
	| 307 | 5413A    | Footwear manufacturing operative                              |
	| 308 | 3567B    | Forensic collision investigator                               |
	| 309 | 2426B    | Forensic computer analyst                                     |
	| 310 | 2212C    | Forensic psychologist                                         |
	| 311 | 2112A    | Forensic scientist                                            |
	| 312 | 9112A    | Forestry worker                                               |
	| 313 | 8222A    | Forklift driver                                               |
	| 314 | 5223F    | Forklift truck engineer                                       |
	| 315 | 5442F    | Formworker                                                    |
	| 316 | 6144B    | Foster carer                                                  |
	| 317 | 5212A    | Foundry mould maker                                           |
	| 318 | 9139A    | Foundry process operator                                      |
	| 319 | 1190A    | Franchise owner                                               |
	| 320 | 5323A    | French polisher                                               |
	| 321 | 6148A    | Funeral director                                              |
	| 322 | 3422G    | Furniture designer                                            |
	| 323 | 5442A    | Furniture maker                                               |
	| 324 | 5442B    | Furniture restorer                                            |
	| 325 | 2312A    | Further education lecturer                                    |
	| 326 | 5119E    | Gamekeeper                                                    |
	| 327 | 1252A    | Garage manager                                                |
	| 328 | 5113A    | Gardener                                                      |
	| 329 | 2461A    | Garment technologist                                          |
	| 330 | 5314B    | Gas mains layer                                               |
	| 331 | 5314C    | Gas service technician                                        |
	| 332 | 2434B    | General practice surveyor                                     |
	| 333 | 2112N    | Geneticist                                                    |
	| 334 | 2113C    | Geoscientist                                                  |
	| 335 | 3539B    | Geospatial  technician                                        |
	| 336 | 3111A    | Geotechnician                                                 |
	| 337 | 5441B    | Glassmaker                                                    |
	| 338 | 5316A    | Glazier                                                       |
	| 339 | 2211A    | GP                                                            |
	| 340 | 1241A    | GP practice manager                                           |
	| 341 | 3421A    | Graphic designer                                              |
	| 342 | 5114A    | Groundsperson                                                 |
	| 343 | 6221A    | Hairdresser                                                   |
	| 344 | 9119B    | Handyperson                                                   |
	| 345 | 5434B    | Head chef                                                     |
	| 346 | 2317A    | Headteacher                                                   |
	| 347 | 3567A    | Health and safety adviser                                     |
	| 348 | 3219G    | Health play specialist                                        |
	| 349 | 2219C    | Health promotion specialist                                   |
	| 350 | 4131A    | Health records clerk                                          |
	| 351 | 1181A    | Health service manager                                        |
	| 352 | 3239F    | Health trainer                                                |
	| 353 | 2231F    | Health visitor                                                |
	| 354 | 6141A    | Healthcare assistant                                          |
	| 355 | 6141C    | Healthcare science assistant                                  |
	| 356 | 5314D    | Heating and ventilation engineer                              |
	| 357 | 5235A    | Helicopter engineer                                           |
	| 358 | 3512B    | Helicopter pilot                                              |
	| 359 | 2141E    | Heritage officer                                              |
	| 360 | 2311A    | Higher education lecturer                                     |
	| 361 | 9232A    | Highways cleaner                                              |
	| 362 | 3219L    | Homeopath                                                     |
	| 363 | 6139G    | Horse groom                                                   |
	| 364 | 3442E    | Horse riding instructor                                       |
	| 365 | 1211A    | Horticultural manager                                         |
	| 366 | 3219H    | Horticultural therapist                                       |
	| 367 | 9119C    | Horticultural worker                                          |
	| 368 | 2211B    | Hospital doctor                                               |
	| 369 | 9271A    | Hospital porter                                               |
	| 370 | 1221A    | Hotel manager                                                 |
	| 371 | 9279A    | Hotel porter                                                  |
	| 372 | 9233B    | Hotel room attendant                                          |
	| 373 | 6231A    | Housekeeper                                                   |
	| 374 | 3234A    | Housing officer                                               |
	| 375 | 3561C    | Housing policy officer                                        |
	| 376 | 3562B    | Human resources officer                                       |
	| 377 | 2113L    | Hydrologist                                                   |
	| 378 | 3219I    | Hypnotherapist                                                |
	| 379 | 3411C    | Illustrator                                                   |
	| 380 | 2419B    | Immigration adviser (non-government)                          |
	| 381 | 3319E    | Immigration officer                                           |
	| 382 | 3536A    | Import-export clerk                                           |
	| 383 | 4131B    | Indexer                                                       |
	| 384 | 9132A    | Industrial cleaner                                            |
	| 385 | 2451A    | Information scientist                                         |
	| 386 | 3538B    | Insurance account manager                                     |
	| 387 | 3532B    | Insurance broker                                              |
	| 388 | 4132A    | Insurance claims handler                                      |
	| 389 | 3531E    | Insurance loss adjuster                                       |
	| 390 | 2423C    | Insurance risk surveyor                                       |
	| 391 | 4132B    | Insurance technician                                          |
	| 392 | 3533A    | Insurance underwriter                                         |
	| 393 | 2426A    | Intelligence analyst                                          |
	| 394 | 3422A    | Interior designer                                             |
	| 395 | 3412A    | Interpreter                                                   |
	| 396 | 3534B    | Investment analyst                                            |
	| 397 | 2134B    | IT project manager                                            |
	| 398 | 2139B    | IT security co-ordinator                                      |
	| 399 | 5245A    | IT service engineer                                           |
	| 400 | 3132A    | IT support technician                                         |
	| 401 | 3563A    | IT trainer                                                    |
	| 402 | 3422I    | Jewellery designer-maker                                      |
	| 403 | 3441C    | Jockey                                                        |
	| 404 | 2412D    | Judge                                                         |
	| 405 | 6139H    | Kennel worker                                                 |
	| 406 | 3422O    | Kitchen and bathroom designer                                 |
	| 407 | 5315B    | Kitchen and bathroom fitter                                   |
	| 408 | 9272B    | Kitchen porter                                                |
	| 409 | 5411A    | Knitting machinist                                            |
	| 410 | 3111B    | Laboratory technician                                         |
	| 411 | 3531F    | Land and property valuer and auctioneer                       |
	| 412 | 2434C    | Land surveyor                                                 |
	| 413 | 2431B    | Landscape architect                                           |
	| 414 | 5113B    | Landscaper                                                    |
	| 415 | 8211A    | Large goods vehicle driver                                    |
	| 416 | 9234C    | Laundry worker                                                |
	| 417 | 2231G    | Learning disability nurse                                     |
	| 418 | 3233B    | Learning mentor                                               |
	| 419 | 5413B    | Leather craftworker                                           |
	| 420 | 5413C    | Leather technologist                                          |
	| 421 | 3520B    | Legal executive                                               |
	| 422 | 4212A    | Legal secretary                                               |
	| 423 | 6211C    | Leisure centre assistant                                      |
	| 424 | 1225A    | Leisure centre manager                                        |
	| 425 | 3544B    | Letting agent                                                 |
	| 426 | 2451B    | Librarian                                                     |
	| 427 | 4135A    | Library assistant                                             |
	| 428 | 3520C    | Licensed conveyancer                                          |
	| 429 | 3235C    | Life coach                                                    |
	| 430 | 6211D    | Lifeguard                                                     |
	| 431 | 5223G    | Lift engineer                                                 |
	| 432 | 5241D    | Lighting technician                                           |
	| 433 | 3417G    | Live sound engineer                                           |
	| 434 | 4113A    | Local government administrative assistant                     |
	| 435 | 4113B    | Local government officer                                      |
	| 436 | 4113C    | Local government revenues officer                             |
	| 437 | 5223H    | Locksmith                                                     |
	| 438 | 2471E    | Magazine journalist                                           |
	| 439 | 2412E    | Magistrate                                                    |
	| 440 | 5223I    | Maintenance fitter                                            |
	| 441 | 6222G    | Make-up artist                                                |
	| 442 | 2421B    | Management accountant                                         |
	| 443 | 2423D    | Management consultant                                         |
	| 444 | 2127B    | Manufacturing systems engineer                                |
	| 445 | 2122E    | Marine engineer                                               |
	| 446 | 3113G    | Marine engineering technician                                 |
	| 447 | 3543F    | Market research data analyst                                  |
	| 448 | 3543G    | Market research executive                                     |
	| 449 | 7215A    | Market researcher                                             |
	| 450 | 7124A    | Market trader                                                 |
	| 451 | 3543H    | Marketing executive                                           |
	| 452 | 3545A    | Marketing manager                                             |
	| 453 | 3442F    | Martial arts instructor                                       |
	| 454 | 3219B    | Massage therapist                                             |
	| 455 | 2129E    | Materials engineer                                            |
	| 456 | 3115A    | Materials technician                                          |
	| 457 | 6141D    | Maternity support worker                                      |
	| 458 | 3565C    | Meat hygiene inspector                                        |
	| 459 | 8111D    | Meat process worker                                           |
	| 460 | 2122A    | Mechanical engineer                                           |
	| 461 | 3113H    | Mechanical engineering technician                             |
	| 462 | 2426E    | Media researcher                                              |
	| 463 | 2229J    | Medical herbalist                                             |
	| 464 | 3411D    | Medical illustrator                                           |
	| 465 | 2113D    | Medical physicist                                             |
	| 466 | 3542C    | Medical sales representative                                  |
	| 467 | 4211A    | Medical secretary                                             |
	| 468 | 2231B    | Mental health nurse                                           |
	| 469 | 3513A    | Merchant Navy deck officer                                    |
	| 470 | 3513B    | Merchant Navy engineering officer                             |
	| 471 | 8232A    | Merchant Navy rating                                          |
	| 472 | 2113E    | Meteorologist                                                 |
	| 473 | 3111C    | Metrologist                                                   |
	| 474 | 2112I    | Microbiologist                                                |
	| 475 | 2129H    | Microbrewer                                                   |
	| 476 | 2232A    | Midwife                                                       |
	| 477 | 5449E    | Model maker                                                   |
	| 478 | 3235D    | Money adviser                                                 |
	| 479 | 2315C    | Montessori teacher                                            |
	| 480 | 3534C    | Mortgage adviser                                              |
	| 481 | 5231A    | Motor mechanic                                                |
	| 482 | 5231C    | Motor vehicle breakdown engineer                              |
	| 483 | 5231D    | Motor vehicle fitter                                          |
	| 484 | 7115B    | Motor vehicle parts person                                    |
	| 485 | 5231E    | Motorcycle mechanic                                           |
	| 486 | 2122F    | Motorsport engineer                                           |
	| 487 | 1116A    | MP                                                            |
	| 488 | 6211E    | Museum attendant                                              |
	| 489 | 2452C    | Museum curator                                                |
	| 490 | 3545C    | Music promotions manager                                      |
	| 491 | 2319E    | Music teacher                                                 |
	| 492 | 2229K    | Music therapist                                               |
	| 493 | 5449A    | Musical instrument maker and repairer                         |
	| 494 | 3415A    | Musician                                                      |
	| 495 | 6222D    | Nail technician                                               |
	| 496 | 6122B    | Nanny                                                         |
	| 497 | 2113F    | Nanotechnologist                                              |
	| 498 | 3219J    | Naturopath                                                    |
	| 499 | 2122G    | Naval architect                                               |
	| 500 | 9242B    | Neighbourhood warden                                          |
	| 501 | 2139C    | Network engineer                                              |
	| 502 | 2133B    | Network manager                                               |
	| 503 | 2471F    | Newspaper journalist                                          |
	| 504 | 2471G    | Newspaper or magazine editor                                  |
	| 505 | 3115B    | Non-destructive testing technician                            |
	| 506 | 2129F    | Nuclear engineer                                              |
	| 507 | 3113I    | Nuclear technician                                            |
	| 508 | 2231C    | Nurse                                                         |
	| 509 | 2319B    | Nursery manager                                               |
	| 510 | 6121A    | Nursery worker                                                |
	| 511 | 3218F    | Nursing associate                                             |
	| 512 | 3219K    | Nutritional therapist                                         |
	| 513 | 2229L    | Nutritionist                                                  |
	| 514 | 2231H    | Occupational health nurse                                     |
	| 515 | 2222A    | Occupational therapist                                        |
	| 516 | 6141E    | Occupational therapy support worker                           |
	| 517 | 2113G    | Oceanographer                                                 |
	| 518 | 4161A    | Office manager                                                |
	| 519 | 8123A    | Offshore drilling worker                                      |
	| 520 | 2318B    | Ofsted inspector                                              |
	| 521 | 1123A    | Oil and gas operations manager                                |
	| 522 | 3563B    | Online tutor                                                  |
	| 523 | 2231I    | Operating department practitioner                             |
	| 524 | 3539A    | Operational researcher                                        |
	| 525 | 2214A    | Optometrist                                                   |
	| 526 | 9260E    | Order picker                                                  |
	| 527 | 2229M    | Orthoptist                                                    |
	| 528 | 2229N    | Osteopath                                                     |
	| 529 | 3442G    | Outdoor activities instructor                                 |
	| 530 | 3422J    | Packaging technologist                                        |
	| 531 | 9134C    | Packer                                                        |
	| 532 | 2211G    | Paediatrician                                                 |
	| 533 | 5234A    | Paint sprayer                                                 |
	| 534 | 5323B    | Painter and decorator                                         |
	| 535 | 2113H    | Palaeontologist                                               |
	| 536 | 6145B    | Palliative care assistant                                     |
	| 537 | 8121A    | Paper maker                                                   |
	| 538 | 3520D    | Paralegal                                                     |
	| 539 | 3213A    | Paramedic                                                     |
	| 540 | 2462A    | Patent attorney                                               |
	| 541 | 2112K    | Pathologist                                                   |
	| 542 | 3561D    | Patient advice and liaison service officer                    |
	| 543 | 7214B    | Patient transport service controller                          |
	| 544 | 5414C    | Pattern cutter                                                |
	| 545 | 4122B    | Payroll administrator                                         |
	| 546 | 4122C    | Payroll manager                                               |
	| 547 | 2314B    | PE teacher                                                    |
	| 548 | 4132C    | Pensions administrator                                        |
	| 549 | 3534D    | Pensions adviser                                              |
	| 550 | 2119B    | Performance sports scientist                                  |
	| 551 | 4215A    | Personal assistant                                            |
	| 552 | 7111B    | Personal shopper                                              |
	| 553 | 3443A    | Personal trainer                                              |
	| 554 | 6132A    | Pest control technician                                       |
	| 555 | 2229O    | Pet behaviour consultant                                      |
	| 556 | 7111C    | Pet shop assistant                                            |
	| 557 | 2213A    | Pharmacist                                                    |
	| 558 | 2112L    | Pharmacologist                                                |
	| 559 | 7114A    | Pharmacy assistant                                            |
	| 560 | 3217A    | Pharmacy technician                                           |
	| 561 | 6141F    | Phlebotomist                                                  |
	| 562 | 3417B    | Photographer                                                  |
	| 563 | 7125A    | Photographic stylist                                          |
	| 564 | 3417H    | Photographic technician                                       |
	| 565 | 2219E    | Physician associate                                           |
	| 566 | 2113I    | Physicist                                                     |
	| 567 | 2221A    | Physiotherapist                                               |
	| 568 | 6141G    | Physiotherapy assistant                                       |
	| 569 | 5442C    | Picture framer                                                |
	| 570 | 3443C    | Pilates teacher                                               |
	| 571 | 5216A    | Pipe fitter                                                   |
	| 572 | 2434E    | Planning and development surveyor                             |
	| 573 | 5321A    | Plasterer                                                     |
	| 574 | 2229A    | Play therapist                                                |
	| 575 | 6123A    | Playworker                                                    |
	| 576 | 5314A    | Plumber                                                       |
	| 577 | 2218A    | Podiatrist                                                    |
	| 578 | 6141H    | Podiatry assistant                                            |
	| 579 | 3315A    | Police community support officer                              |
	| 580 | 3312A    | Police officer                                                |
	| 581 | 9260B    | Port operative                                                |
	| 582 | 3233C    | Portage home visitor                                          |
	| 583 | 7111D    | Post Office customer service assistant                        |
	| 584 | 9211A    | Postperson                                                    |
	| 585 | 2231J    | Practice nurse                                                |
	| 586 | 5421A    | Pre-press operator                                            |
	| 587 | 2315A    | Primary school teacher                                        |
	| 588 | 1173A    | Prison governor                                               |
	| 589 | 3563C    | Prison instructor                                             |
	| 590 | 3314A    | Prison officer                                                |
	| 591 | 2421C    | Private practice accountant                                   |
	| 592 | 2443A    | Probation officer                                             |
	| 593 | 3239A    | Probation services officer                                    |
	| 594 | 3422K    | Product designer                                              |
	| 595 | 1121C    | Production manager (manufacturing)                            |
	| 596 | 8111A    | Production worker (manufacturing)                             |
	| 597 | 4159A    | Proofreader                                                   |
	| 598 | 5449B    | Prop maker                                                    |
	| 599 | 3218E    | Prosthetist-orthotist                                         |
	| 600 | 2211E    | Psychiatrist                                                  |
	| 601 | 2229P    | Psychological wellbeing practitioner                          |
	| 602 | 2212A    | Psychologist                                                  |
	| 603 | 2229B    | Psychotherapist                                               |
	| 604 | 2421D    | Public finance accountant                                     |
	| 605 | 1134A    | Public relations director                                     |
	| 606 | 2472C    | Public relations officer                                      |
	| 607 | 1224A    | Publican                                                      |
	| 608 | 1133B    | Purchasing manager                                            |
	| 609 | 3563D    | QCF assessor                                                  |
	| 610 | 2462B    | Quality assurance manager                                     |
	| 611 | 3115C    | Quality control assistant                                     |
	| 612 | 2433A    | Quantity surveyor                                             |
	| 613 | 2121B    | Quarry engineer                                               |
	| 614 | 8123B    | Quarry worker                                                 |
	| 615 | 1213A    | Racehorse trainer                                             |
	| 616 | 3416B    | Radio broadcast assistant                                     |
	| 617 | 2217A    | Radiographer                                                  |
	| 618 | 6141I    | Radiography assistant                                         |
	| 619 | 3311B    | RAF airman or airwoman                                        |
	| 620 | 3311C    | RAF non-commissioned aircrew                                  |
	| 621 | 1171B    | RAF officer                                                   |
	| 622 | 8143A    | Rail track maintenance worker                                 |
	| 623 | 8234A    | Railway signaller                                             |
	| 624 | 4216B    | Receptionist                                                  |
	| 625 | 3562C    | Recruitment consultant                                        |
	| 626 | 9235B    | Recycled metals worker                                        |
	| 627 | 3561E    | Recycling officer                                             |
	| 628 | 9235C    | Recycling operative                                           |
	| 629 | 3219C    | Reflexologist                                                 |
	| 630 | 5225A    | Refrigeration and air-conditioning installer                  |
	| 631 | 2429A    | Registrar of births, deaths, marriages and civil partnerships |
	| 632 | 9279B    | Reiki healer                                                  |
	| 633 | 2444A    | Religious leader                                              |
	| 634 | 9260C    | Removals worker                                               |
	| 635 | 9219A    | Reprographic assistant                                        |
	| 636 | 2119C    | Research scientist                                            |
	| 637 | 6145C    | Residential support worker                                    |
	| 638 | 6219C    | Resort representative                                         |
	| 639 | 1223C    | Restaurant manager                                            |
	| 640 | 3541B    | Retail buyer                                                  |
	| 641 | 1190B    | Retail manager                                                |
	| 642 | 7125B    | Retail merchandiser                                           |
	| 643 | 1161B    | Road transport manager                                        |
	| 644 | 8142A    | Road worker                                                   |
	| 645 | 9275C    | Roadie                                                        |
	| 646 | 2126D    | Robotics engineer                                             |
	| 647 | 5237A    | Rolling stock engineering technician                          |
	| 648 | 5313A    | Roofer                                                        |
	| 649 | 9139B    | Roustabout                                                    |
	| 650 | 3311D    | Royal Marines commando                                        |
	| 651 | 1171C    | Royal Marines officer                                         |
	| 652 | 1171D    | Royal Navy officer                                            |
	| 653 | 3311E    | Royal Navy rating                                             |
	| 654 | 3565D    | RSPCA inspector                                               |
	| 655 | 2434F    | Rural surveyor                                                |
	| 656 | 3442H    | Sailing instructor                                            |
	| 657 | 4151A    | Sales administrator                                           |
	| 658 | 7111E    | Sales assistant                                               |
	| 659 | 3545D    | Sales manager                                                 |
	| 660 | 3542A    | Sales representative                                          |
	| 661 | 5244A    | Satellite engineer                                            |
	| 662 | 8141A    | Scaffolder                                                    |
	| 663 | 3319F    | Scenes of crime officer                                       |
	| 664 | 2317B    | School business manager                                       |
	| 665 | 9244A    | School crossing patrol                                        |
	| 666 | 6144C    | School houseparent                                            |
	| 667 | 9244B    | School lunchtime supervisor                                   |
	| 668 | 2231K    | School nurse                                                  |
	| 669 | 4213A    | School secretary                                              |
	| 670 | 3412E    | Screenwriter                                                  |
	| 671 | 2314A    | Secondary school teacher                                      |
	| 672 | 4215D    | Secretary                                                     |
	| 673 | 3319G    | Security manager                                              |
	| 674 | 9241A    | Security officer                                              |
	| 675 | 2426D    | Security Service personnel                                    |
	| 676 | 5249B    | Security systems installer                                    |
	| 677 | 2113K    | Seismologist                                                  |
	| 678 | 6146A    | Senior care worker                                            |
	| 679 | 3422L    | Set designer                                                  |
	| 680 | 8137B    | Sewing machinist                                              |
	| 681 | 9251A    | Shelf filler                                                  |
	| 682 | 5413D    | Shoe repairer                                                 |
	| 683 | 5315D    | Shopfitter                                                    |
	| 684 | 1223B    | Shopkeeper                                                    |
	| 685 | 5249C    | Signalling technician                                         |
	| 686 | 5449C    | Signmaker                                                     |
	| 687 | 5449D    | Signwriter                                                    |
	| 688 | 2319D    | Skills for life teacher                                       |
	| 689 | 5241E    | Smart meter installer                                         |
	| 690 | 2472A    | Social media manager                                          |
	| 691 | 1184A    | Social services manager                                       |
	| 692 | 3239B    | Social work assistant                                         |
	| 693 | 2442A    | Social worker                                                 |
	| 694 | 2136B    | Software developer                                            |
	| 695 | 3311F    | Soldier                                                       |
	| 696 | 2413A    | Solicitor                                                     |
	| 697 | 2135A    | Solutions architect                                           |
	| 698 | 2217B    | Sonographer                                                   |
	| 699 | 2316A    | Special educational needs (SEN) teacher                       |
	| 700 | 6126A    | Special educational needs (SEN) teaching assistant            |
	| 701 | 2223A    | Speech and language therapist                                 |
	| 702 | 6141J    | Speech and language therapy assistant                         |
	| 703 | 2212D    | Sport and exercise psychologist                               |
	| 704 | 3442A    | Sports coach                                                  |
	| 705 | 3413I    | Sports commentator                                            |
	| 706 | 3442J    | Sports development officer                                    |
	| 707 | 2221B    | Sports physiotherapist                                        |
	| 708 | 3441A    | Sports professional                                           |
	| 709 | 3416D    | Stage manager                                                 |
	| 710 | 3417I    | Stagehand                                                     |
	| 711 | 5311A    | Steel erector                                                 |
	| 712 | 5319C    | Steel fixer                                                   |
	| 713 | 5319D    | Steeplejack                                                   |
	| 714 | 6141K    | Sterile services technician                                   |
	| 715 | 4133A    | Stock control assistant                                       |
	| 716 | 3532A    | Stockbroker                                                   |
	| 717 | 5321B    | Stonemason                                                    |
	| 718 | 9241D    | Store detective                                               |
	| 719 | 7123B    | Street food trader                                            |
	| 720 | 2121C    | Structural engineer                                           |
	| 721 | 3417C    | Studio sound engineer                                         |
	| 722 | 2471H    | Sub-editor                                                    |
	| 723 | 3239G    | Substance misuse outreach worker                              |
	| 724 | 4162A    | Supervisor                                                    |
	| 725 | 1133C    | Supply chain manager                                          |
	| 726 | 2211F    | Surgeon                                                       |
	| 727 | 3114C    | Surveying technician                                          |
	| 728 | 3442K    | Swimming teacher                                              |
	| 729 | 2135B    | Systems analyst                                               |
	| 730 | 5414D    | Tailor                                                        |
	| 731 | 8211B    | Tanker driver                                                 |
	| 732 | 6222E    | Tattooist and body piercer                                    |
	| 733 | 3535A    | Tax adviser                                                   |
	| 734 | 3535B    | Tax inspector                                                 |
	| 735 | 8214A    | Taxi driver                                                   |
	| 736 | 6148E    | Taxidermist                                                   |
	| 737 | 6125A    | Teaching assistant                                            |
	| 738 | 2135C    | Technical architect                                           |
	| 739 | 3412F    | Technical author                                              |
	| 740 | 2129G    | Technical brewer                                              |
	| 741 | 3422M    | Technical textiles designer                                   |
	| 742 | 5242A    | Telecoms engineer                                             |
	| 743 | 7213A    | Telephonist                                                   |
	| 744 | 2133C    | Test lead                                                     |
	| 745 | 3422N    | Textile designer                                              |
	| 746 | 3116A    | Textile dyeing technician                                     |
	| 747 | 9139C    | Textile operative                                             |
	| 748 | 1121B    | Textiles production manager                                   |
	| 749 | 5313B    | Thatcher                                                      |
	| 750 | 8149G    | Thermal insulation engineer                                   |
	| 751 | 5313C    | Tiler                                                         |
	| 752 | 5222A    | Toolmaker                                                     |
	| 753 | 6219D    | Tour manager                                                  |
	| 754 | 6219A    | Tourist guide                                                 |
	| 755 | 6219E    | Tourist information centre assistant                          |
	| 756 | 2432A    | Town planner                                                  |
	| 757 | 3121B    | Town planning assistant                                       |
	| 758 | 8223A    | Tractor driver                                                |
	| 759 | 2462C    | Trade mark attorney                                           |
	| 760 | 4114A    | Trade union official                                          |
	| 761 | 3565E    | Trading standards officer                                     |
	| 762 | 6215A    | Train conductor                                               |
	| 763 | 8231A    | Train driver                                                  |
	| 764 | 6215B    | Train station worker                                          |
	| 765 | 3563E    | Training manager                                              |
	| 766 | 3563F    | Training officer                                              |
	| 767 | 8231B    | Tram driver                                                   |
	| 768 | 3412G    | Translator                                                    |
	| 769 | 2436B    | Transport planner                                             |
	| 770 | 1226A    | Travel agency manager                                         |
	| 771 | 6212A    | Travel agent                                                  |
	| 772 | 5119F    | Tree surgeon                                                  |
	| 773 | 3416E    | TV or film assistant director                                 |
	| 774 | 3416H    | TV or film assistant production co-ordinator                  |
	| 775 | 3417J    | TV or film camera operator                                    |
	| 776 | 3416F    | TV or film director                                           |
	| 777 | 3416G    | TV or film producer                                           |
	| 778 | 1259C    | TV or film production manager                                 |
	| 779 | 9219B    | TV or film production runner                                  |
	| 780 | 3417K    | TV or film sound technician                                   |
	| 781 | 3413A    | TV presenter                                                  |
	| 782 | 5412A    | Upholsterer                                                   |
	| 783 | 2137A    | User experience (UX) designer                                 |
	| 784 | 2426C    | User researcher                                               |
	| 785 | 5232A    | Vehicle body repairer                                         |
	| 786 | 7122A    | Vending machine operator                                      |
	| 787 | 2216A    | Vet                                                           |
	| 788 | 6131A    | Veterinary nurse                                              |
	| 789 | 2221C    | Veterinary physiotherapist                                    |
	| 790 | 4112D    | Victim care officer                                           |
	| 791 | 3416I    | Video editor                                                  |
	| 792 | 1225B    | Visitor attraction general manager                            |
	| 793 | 7125C    | Visual merchandiser                                           |
	| 794 | 3413H    | Vlogger                                                       |
	| 795 | 9273A    | Waiter                                                        |
	| 796 | 6211F    | Wardrobe assistant                                            |
	| 797 | 1162A    | Warehouse manager                                             |
	| 798 | 9260A    | Warehouse worker                                              |
	| 799 | 5224B    | Watch or clock repairer                                       |
	| 800 | 8126B    | Water network operative                                       |
	| 801 | 8126C    | Water treatment worker                                        |
	| 802 | 2137B    | Web content editor                                            |
	| 803 | 2137C    | Web content manager                                           |
	| 804 | 2137D    | Web designer                                                  |
	| 805 | 2137E    | Web developer                                                 |
	| 806 | 3546C    | Wedding planner                                               |
	| 807 | 5215A    | Welder                                                        |
	| 808 | 3239C    | Welfare rights officer                                        |
	| 809 | 3113J    | Wind turbine technician                                       |
	| 810 | 9231A    | Window cleaner                                                |
	| 811 | 5316C    | Window fabricator                                             |
	| 812 | 5316B    | Window fitter                                                 |
	| 813 | 8135A    | Windscreen fitter                                             |
	| 814 | 1254D    | Wine merchant                                                 |
	| 815 | 8121B    | Wood machinist                                                |
	| 816 | 3412H    | Writer                                                        |
	| 817 | 3443D    | Yoga teacher                                                  |
	| 818 | 3443E    | Yoga therapist                                                |
	| 819 | 2443B    | Youth offending team officer                                  |
	| 820 | 3231E    | Youth worker                                                  |
	| 821 | 6139A    | Zookeeper                                                     |
	| 822 | 2112M    | Zoologist                                                     |
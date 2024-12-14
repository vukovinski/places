namespace places.lib;

public static class PlaceTypes
{
    public enum Category
    {
        Automotive,
        Business,
        Culture,
        Education,
        EntertainmentAndRecreation,
        Facilities,
        Finance,
        FoodAndDrink,
        GeographicalAreas,
        Government,
        HealthAndWelness,
        Housing,
        Lodging,
        NaturalFeatures,
        PlacesOfWorship,
        Services,
        Shopping,
        Sports,
        Transportation
    }

    public static Category GetCategory(string placeType)
    {
        placeType = placeType.Trim();
        if (Automotive.Contains(placeType)) return Category.Automotive;
        if (Business.Contains(placeType)) return Category.Business;
        if (Culture.Contains(placeType)) return Category.Culture;
        if (Education.Contains(placeType)) return Category.Education;
        if (EntertainmentAndRecreation.Contains(placeType)) return Category.EntertainmentAndRecreation;
        if (Facilities.Contains(placeType)) return Category.Facilities;
        if (Finance.Contains(placeType)) return Category.Finance;
        if (FoodAndDrink.Contains(placeType)) return Category.FoodAndDrink;
        if (GeographicalAreas.Contains(placeType)) return Category.GeographicalAreas;
        if (Government.Contains(placeType)) return Category.Government;
        if (HealthAndWelness.Contains(placeType)) return Category.HealthAndWelness;
        if (Housing.Contains(placeType)) return Category.Housing;
        if (Lodging.Contains(placeType)) return Category.Lodging;
        if (NaturalFeatures.Contains(placeType)) return Category.NaturalFeatures;
        if (PlacesOfWorship.Contains(placeType)) return Category.PlacesOfWorship;
        if (Services.Contains(placeType)) return Category.Services;
        if (Shopping.Contains(placeType)) return Category.Shopping;
        if (Sports.Contains(placeType)) return Category.Sports;
        if (Transportation.Contains(placeType)) return Category.Transportation;

        throw new NotSupportedException("Unknown place type!");
    }

    public static IReadOnlyList<string> GetPlaceTypesFromCategory(Category category)
    {
        if (category == Category.Automotive) return Automotive;
        if (category == Category.Business) return Business;
        if (category == Category.Culture) return Culture;
        if (category == Category.Education) return Education;
        if (category == Category.EntertainmentAndRecreation) return EntertainmentAndRecreation;
        if (category == Category.Facilities) return Facilities;
        if (category == Category.Finance) return Finance;
        if (category == Category.FoodAndDrink) return FoodAndDrink;
        if (category == Category.GeographicalAreas) return GeographicalAreas;
        if (category == Category.Government) return Government;
        if (category == Category.HealthAndWelness) return HealthAndWelness;
        if (category == Category.Housing) return Housing;
        if (category == Category.Lodging) return Lodging;
        if (category == Category.NaturalFeatures) return NaturalFeatures;
        if (category == Category.PlacesOfWorship) return PlacesOfWorship;
        if (category == Category.Services) return Services;
        if (category == Category.Shopping) return Shopping;
        if (category == Category.Sports) return Sports;
        if (category == Category.Transportation) return Transportation;

        throw new NotSupportedException("Unknown category!");
    }

    public static readonly IReadOnlyList<string> Automotive =
    [
        "car_dealer",
        "car_rental",
        "car_repair",
        "car_wash",
        "electric_vehicle_charging_station",
        "gas_station",
        "parking",
        "rest_stop"
    ];

    public static readonly IReadOnlyList<string> Business =
    [
        "corporate_office",
        "farm",
        "ranch"
    ];

    public static readonly IReadOnlyList<string> Culture =
    [
        "art_gallery",
        "art_studio",
        "auditorium",
        "cultural_landmark",
        "historical_place",
        "monument",
        "museum",
        "performing_arts_theater",
        "sculpture"
    ];

    public static readonly IReadOnlyList<string> Education =
    [
        "library",
        "preschool",
        "primary_school",
        "school",
        "secondary_school",
        "university"
    ];

    public static readonly IReadOnlyList<string> EntertainmentAndRecreation =
    [
        "adventure_sports_center",
        "amphitheatre",
        "amusement_center",
        "amusement_park",
        "aquarium",
        "banquet_hall",
        "barbecue_area",
        "botanical_garden",
        "bowling_alley",
        "casino",
        "childrens_camp",
        "comedy_club",
        "community_center",
        "concert_hall",
        "convention_center",
        "cultural_center",
        "cycling_park",
        "dance_hall",
        "dog_park",
        "event_venue",
        "ferris_wheel",
        "garden",
        "hiking_area",
        "historical_landmark",
        "internet_cafe",
        "karaoke",
        "marina",
        "movie_rental",
        "movie_theater",
        "national_park",
        "night_club",
        "observation_deck",
        "off_roading_area",
        "opera_house",
        "park",
        "philharmonic_hall",
        "picnic_ground",
        "planetarium",
        "plaza",
        "roller_coaster",
        "skateboard_park",
        "state_park",
        "tourist_attraction",
        "video_arcade",
        "visitor_center",
        "water_park",
        "wedding_venue",
        "wildlife_park",
        "wildlife_refuge",
        "zoo"
    ];

    public static readonly IReadOnlyList<string> Facilities =
    [
        "public_bath",
        "public_bathroom",
        "stable"
    ];

    public static readonly IReadOnlyList<string> Finance =
    [
        "accounting",
        "atm",
        "bank"
    ];

    public static readonly IReadOnlyList<string> FoodAndDrink =
    [
        "acai_shop",
        "afghani_restaurant",
        "african_restaurant",
        "american_restaurant",
        "asian_restaurant",
        "bagel_shop",
        "bakery",
        "bar",
        "bar_and_grill",
        "barbecue_restaurant",
        "brazilian_restaurant",
        "breakfast_restaurant",
        "brunch_restaurant",
        "buffet_restaurant",
        "cafe",
        "cafeteria",
        "candy_store",
        "cat_cafe",
        "chinese_restaurant",
        "chocolate_factory",
        "chocolate_shop",
        "coffee_shop",
        "confectionery",
        "deli",
        "dessert_restaurant",
        "dessert_shop",
        "diner",
        "dog_cafe",
        "donut_shop",
        "fast_food_restaurant",
        "fine_dining_restaurant",
        "food_court",
        "french_restaurant",
        "greek_restaurant",
        "hamburger_restaurant",
        "ice_cream_shop",
        "indian_restaurant",
        "indonesian_restaurant",
        "italian_restaurant",
        "japanese_restaurant",
        "juice_shop",
        "korean_restaurant",
        "lebanese_restaurant",
        "meal_delivery",
        "meal_takeaway",
        "mediterranean_restaurant",
        "mexican_restaurant",
        "middle_eastern_restaurant",
        "pizza_restaurant",
        "pub",
        "ramen_restaurant",
        "restaurant",
        "sandwich_shop",
        "seafood_restaurant",
        "spanish_restaurant",
        "steak_house",
        "sushi_restaurant",
        "tea_house",
        "thai_restaurant",
        "turkish_restaurant",
        "vegan_restaurant",
        "vegetarian_restaurant",
        "vietnamese_restaurant",
        "wine_bar"
    ];

    public static readonly IReadOnlyList<string> GeographicalAreas =
    [
        "administrative_area_level_1",
        "administrative_area_level_2",
        "country",
        "locality",
        "postal_code",
        "school_district"
    ];

    public static readonly IReadOnlyList<string> Government =
    [
        "city_hall",
        "courthouse",
        "embassy",
        "fire_station",
        "goverment_office",
        "local_goverment_office",
        "neighborhood_police_station",
        "police",
        "post_office"
    ];

    public static readonly IReadOnlyList<string> HealthAndWelness =
    [
        "chiropractor",
        "dental_clinic",
        "dentist",
        "doctor",
        "drugstore",
        "hospital",
        "massage",
        "medical_lab",
        "pharmacy",
        "physiotherapist",
        "sauna",
        "skin_care_clinic",
        "spa",
        "tanning_studio",
        "wellness_center",
        "yoga_studio"
    ];

    public static readonly IReadOnlyList<string> Housing =
    [
        "apartment_building",
        "apartment_complex",
        "condominium_complex",
        "housing_complex"
    ];

    public static readonly IReadOnlyList<string> Lodging =
    [
        "bed_and_breakfast",
        "budget_japanese_inn",
        "campground",
        "camping_cabin",
        "cottage",
        "extended_stay_hotel",
        "farmstay",
        "guest_house",
        "hostel",
        "hotel",
        "inn",
        "japanese_inn",
        "lodging",
        "mobile_home_park",
        "motel",
        "private_guest_room",
        "resort_hotel",
        "rv_park"
    ];

    public static readonly IReadOnlyList<string> NaturalFeatures =
    [
        "beach"
    ];

    public static readonly IReadOnlyList<string> PlacesOfWorship =
    [
        "church",
        "hindu_temple",
        "mosque",
        "synagogue"
    ];

    public static readonly IReadOnlyList<string> Services =
    [
        "astrologer",
        "barber_shop",
        "beautician",
        "beauty_salon",
        "body_art_service",
        "catering_service",
        "cemetery",
        "child_care_agency",
        "consultant",
        "courier_service",
        "electrician",
        "florist",
        "food_delivery",
        "foot_care",
        "funeral_home",
        "hair_care",
        "hair_salon",
        "insurance_agency",
        "laundry",
        "lawyer",
        "locksmith",
        "makeup_artist",
        "moving_company",
        "nail_salon",
        "painter",
        "plumber",
        "psychic",
        "real_estate_agency",
        "roofing_contractor",
        "storage",
        "summer_camp_organizer",
        "tailor",
        "telecommunications_service_provider",
        "tour_agency",
        "tourist_information_center",
        "travel_agency",
        "veterinary_care"
    ];

    public static readonly IReadOnlyList<string> Shopping =
    [
        "asian_grocery_store",
        "auto_parts_store",
        "bicycle_store",
        "book_store",
        "butcher_shop",
        "cell_phone_store",
        "clothing_store",
        "convenience_store",
        "department_store",
        "discount_store",
        "electronics_store",
        "food_store",
        "furniture_store",
        "gift_shop",
        "grocery_store",
        "hardware_store",
        "home_goods_store",
        "home_improvement_store",
        "jewelry_store",
        "liquor_store",
        "market",
        "pet_store",
        "shoe_store",
        "shopping_mall",
        "sporting_goods_store",
        "store",
        "supermarket",
        "warehouse_store",
        "wholesaler"
    ];

    public static readonly IReadOnlyList<string> Sports =
    [
        "arena",
        "athletic_field",
        "fishing_charter",
        "fishing_pond",
        "fitness_center",
        "golf_course",
        "gym",
        "ice_skating_rink",
        "playground",
        "ski_resort",
        "sports_activity_location",
        "sports_club",
        "sports_coaching",
        "sports_complex",
        "stadium",
        "swimming_pool"
    ];

    public static readonly IReadOnlyList<string> Transportation =
    [
        "airport",
        "airstrip",
        "bus_station",
        "bus_stop",
        "ferry_terminal",
        "heliport",
        "international_airport",
        "light_rail_station",
        "park_and_ride",
        "subway_station",
        "taxi_stand",
        "train_station",
        "transit_depot",
        "transit_station",
        "truck_stop"
    ];
}

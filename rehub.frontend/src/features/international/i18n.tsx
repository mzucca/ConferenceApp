import i18n from "i18next";
import { initReactI18next  } from "react-i18next";
import translationEnglish from "../../translations/english/rihub.json";
import translationItalian from "../../translations/italian/rihub.json";

i18n
.use(initReactI18next)
.init({
    fallbackLng: 'en',
    debug: true,
    resources:{
        en: {
            translation: translationEnglish,
        },
        it: {
            translation: translationItalian,
        },
    },
    lng:"en", //default language
});

export default i18n;

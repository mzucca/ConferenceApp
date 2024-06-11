import i18n from "i18next";
import { initReactI18next  } from "react-i18next";
import { format as formatDate, formatDistance, formatRelative, isDate } from "date-fns";
import { enUS, it } from "date-fns/locale"; // import all locales we need

import translationEnglish from "../../translations/english/rihub.json";
import translationItalian from "../../translations/italian/rihub.json";

const locales = { enUS, it }; // used to look up the required locale

const default_language ="en";

const resources = {
    en: {
        translation: translationEnglish,
    },
    it: {
        translation: translationItalian,
    },
}
type localeKey = keyof typeof locales;
i18n
.use(initReactI18next)
.init({
    fallbackLng: 'en',
    debug: true,
    resources:resources,
    lng:default_language,
    interpolation : {
        // react already saves from xss
        escapeValue: false,
        format: (value, format, lng) => {
            if (isDate(value)) {
                lng ??=default_language;
                if(lng==='en') lng='enUS';
                const locale = locales[lng as localeKey];
                if (format === "short")
                    {
                        console.log(formatDate(value, "P @ p", { locale }));

                        return formatDate(value, "P @ p", { locale });
                    }
                if (format === "long")
                    return formatDate(value, "PPPP", { locale });
                if (format === "relative")
                    return formatRelative(value, new Date(), { locale });
                if (format === "ago")
                    return formatDistance(value, new Date(), {
                        locale,
                        addSuffix: true
                    });
                return formatDate(value, format!, {locale});
            }
            return value;
        }
    }
});

export default i18n;

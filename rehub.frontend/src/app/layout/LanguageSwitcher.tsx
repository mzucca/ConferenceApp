
import { Dropdown } from 'semantic-ui-react';
import '../../features/international/i18n'

import { useTranslation } from 'react-i18next';
import { SyntheticEvent } from 'react';
export default function RegisterForm() {

    const { i18n  } = useTranslation();
    const languages = ['en','it']; // Get languages from i18n
    const languageNames = new Intl.DisplayNames(i18n.language, { type: 'language' });

    const handleClick = (event: SyntheticEvent, data: object)=>{
        const id = (data as any).id;
        if(id === i18n.language) return;

        i18n.changeLanguage(id);
    }

    return(
        <Dropdown  pointing='top right' icon='globe'>
            <Dropdown.Menu>
                {languages.map((lang) => (
                    <Dropdown.Item 
                        id={lang}
                        key={lang} 
                        active={lang!==i18n.language} 
                        text={languageNames.of(lang)} 
                        onClick={handleClick}>
                    </Dropdown.Item>
                ))}
            </Dropdown.Menu>
        </Dropdown>
        )
}
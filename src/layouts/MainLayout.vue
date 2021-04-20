<template>
  <q-layout view="lHh Lpr lFf">
    <q-header elevated>
      <q-toolbar>
        <q-btn
          flat
          dense
          round
          icon="menu"
          aria-label="Menu"
          @click="leftDrawerOpen = !leftDrawerOpen"
        />

        <q-toolbar-title>
          Quasar App
        </q-toolbar-title>

        <div>Quasar v{{ $q.version }}</div>
      </q-toolbar>
    </q-header>

    <q-drawer
      v-model="leftDrawerOpen"
      show-if-above
      bordered
      content-class="bg-grey-1"
    >
      <q-list>
        <q-item-label
          header
          class="text-grey-8"
        >
          Главное меню
        </q-item-label>
        <q-expansion-item
          v-for="link in essentialLinks"
          :key="link.title"
          expand-separator
          :icon="link.icon"
          :label="link.title"
          :caption="link.caption"
        >
          <EssentialLink
            v-for="child in link.children"
            :key="child.title"
            expand-separator
            :icon="child.icon"
            :title="child.title"
            :caption="child.caption"
            :link="child.link"
            class="q-pl-lg"
          />
        </q-expansion-item>
      </q-list>
    </q-drawer>

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
import {
  mdiAbTesting,
  mdiStore,
  mdiTruckDelivery,
  mdiCart,
  mdiPackageDown,
  mdiBook,
  mdiCurrencyUsd,
  mdiEarth,
  mdiDomain,
  mdiClipboardAccount,
  mdiBank,
  mdiBankTransfer,
  mdiTextBox,
  mdiNoteText,
  mdiNotebookMultiple,
  mdiAccountGroup,
  mdiAccountTie,
  mdiAccountBox
} from '@quasar/extras/mdi-v5'

const linksData = [
  {
    title: 'Справочники',
    caption: 'Справочники',
    icon: mdiBook,
    link: '/dfd',
    children: [
      {
        title: 'Валюта',
        caption: 'Валюта',
        icon: mdiCurrencyUsd,
        link: '/currency'
      },
      {
        title: 'Страны',
        caption: 'Страны',
        icon: mdiEarth,
        link: '/country'
      },
      {
        title: 'Должности',
        caption: 'Должности',
        icon: mdiClipboardAccount,
        link: '/positions/all'
      },
      {
        title: 'Банки',
        caption: 'Банки',
        icon: mdiBank,
        link: '/banks/all'
      },
      {
        title: 'Банковские счета',
        caption: 'Банковские счета',
        icon: mdiBankTransfer,
        link: '/bank-account/all'
      },
      {
        title: ' Компании',
        caption: 'Компании',
        icon: mdiDomain,
        link: '/company'
      },
      {
        title: ' Контрагенты',
        caption: 'Контрагенты',
        icon: mdiDomain,
        link: '/counterparty/all'
      },
      {
        title: ' Партнеры',
        caption: 'Партнеры',
        icon: mdiDomain,
        link: '/partner'
      }
    ]
  },
  {
    title: 'Продажи',
    caption: 'Управление продажами',
    icon: mdiPackageDown,
    children: [
      {
        title: 'Соглашения с клиентами',
        icon: mdiTextBox,
        link: '/standart-agreements'
      },
      {
        title: 'Коммерческие предложения',
        icon: mdiNoteText,
        link: '/business-proposal'
      },
      {
        title: 'Заказы клиентов',
        icon: mdiNotebookMultiple,
        link: '/client-orders'
      }
    ]
  },
  {
    title: 'Закупки',
    caption: 'Управление закупками',
    icon: mdiCart,
    link: 'https://github.com/quasarframework',
    children: [
      {
        title: 'Продажи',
        caption: 'quasar.dev',
        icon: mdiAbTesting,
        link: 'https://quasar.dev'
      },
      {
        title: 'Продажи',
        caption: 'quasar.dev',
        icon: mdiAbTesting,
        link: 'https://quasar.dev'
      }
    ]
  },
  {
    title: 'Маркетинг',
    caption: 'Управление клиентами',
    icon: 'chat',
    link: 'https://chat.quasar.dev',
    children: [
      {
        title: 'Соглашения с клиентами',
        link: 'https://quasar.dev'
      },
      {
        title: 'Клиенты',
        link: 'https://quasar.dev'
      },
      {
        title: 'Создать сделку с клиентом',
        link: 'https://quasar.dev'
      }
    ]
  },
  {
    title: 'Склад',
    caption: 'Контроль запасов',
    icon: mdiStore,
    children: [
      {
        title: 'Единицы хранения',
        caption: 'Единицы хранения',
        icon: mdiAbTesting,
        link: '/store/storage-units'
      },
      {
        title: 'Виды продуктов',
        caption: 'Виды продуктов',
        icon: mdiAbTesting,
        link: '/store/product-categories'
      }
    ]
  },
  {
    title: 'Доставка',
    caption: 'Управление доставкой',
    icon: mdiTruckDelivery,
    link: 'https://twitter.quasar.dev',
    children: [
      {
        title: 'Продажи',
        caption: 'quasar.dev',
        icon: mdiAbTesting,
        link: 'https://quasar.dev'
      },
      {
        title: 'Продажи',
        caption: 'quasar.dev',
        icon: mdiAbTesting,
        link: 'https://quasar.dev'
      }
    ]
  },
  {
    title: 'Управление персоналом',
    caption: 'Управление персоналом',
    icon: mdiAccountGroup,
    children: [
      {
        title: 'Работники',
        caption: 'quasar.dev',
        icon: mdiAccountBox,
        link: '/human-resources/employees/all'
      },
      {
        title: 'Контактные лица',
        caption: 'quasar.dev',
        icon: mdiAccountTie,
        link: '/human-resources/contact-people/all'
      }
    ]
  }
]

import EssentialLink from 'components/EssentialLink'
export default {
  name: 'MainLayout',
  components: {
    EssentialLink
  },
  data () {
    return {
      leftDrawerOpen: false,
      essentialLinks: linksData
    }
  }
}
</script>

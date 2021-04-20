<template>
  <q-page padding>
    <q-table
      title="Банки"
      :data="data"
      :columns="columns"
      row-key="name"
      binary-state-sort
      :loading="loading"
    >
      <template v-slot:top>
        <div class="flex justify-between flex-center" style="width: 100%">
          <h6 class="q-ma-none">Банки</h6>
          <q-btn @click="createBank = true" size="sm" color="secondary" :icon="mdiPencil" label="создать банк" />
        </div>
      </template>
      <template v-slot:body="props">
        <q-tr :props="props">
          <q-td key="name" :props="props">
            {{ props.row.name }}
            <q-popup-edit
              v-model="props.row.name"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.name" dense autofocus counter />
            </q-popup-edit>
          </q-td>
          <q-td key="bic" :props="props">
            {{ props.row.bic }}
            <q-popup-edit
              v-model="props.row.bic"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.bic" dense autofocus />
            </q-popup-edit>
          </q-td>
          <q-td key="corrAccount" :props="props">
            {{ props.row.corrAccount }}
            <q-popup-edit
              v-model="props.row.corrAccount"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.corrAccount" dense autofocus />
            </q-popup-edit>
          </q-td>
          <q-td key="city" :props="props">
            {{ props.row.city }}
            <q-popup-edit
              v-model="props.row.city"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.city" dense autofocus />
            </q-popup-edit>
          </q-td>
          <q-td key="address" :props="props">
            {{ props.row.address }}
            <q-popup-edit
              v-model="props.row.address"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.address" dense autofocus />
            </q-popup-edit>
          </q-td>
          <q-td key="saveChanges" :props="props">
            <q-btn color="primary" size="sm" label="Сохранить" @click="saveChanges(props.row.bic)" :loading="loading" />
            <q-btn class="q-ml-sm" color="secondary" size="sm" label="Просмотр" @click="getBank(props.row.bic)" :loading="loading" />
          </q-td>
        </q-tr>

        <q-dialog v-model="createBank" persistent>
          <q-card style="width: 700px;">
            <q-card-section class="row items-center justify-between">
              <span class="q-ml-sm text-h6 text-primary text-bold q-pb-none">Создание банка.</span>
            </q-card-section>

            <CreateBankPopup />

            <q-card-actions align="right">
              <q-btn flat label="Закрыть" color="primary" v-close-popup />
            </q-card-actions>
          </q-card>
        </q-dialog>

      </template>
    </q-table>
  </q-page>
</template>

<script>
import { mdiPencil } from '@quasar/extras/mdi-v5'
import CreateBankPopup from 'components/creationElements/CreateBankPopup'
export default {
  name: 'PageBanksAll',
  components: {
    CreateBankPopup
  },
  methods: {
    getBank (id) {
      this.$router.push('/bank/' + id)
    }
  },
  data: () => {
    return {
      loading: false,
      mdiPencil,
      createBank: false,
      data: [
        { name: 'JJJJddfdf', bic: 'DFGA', city: 'Москва', corrAccount: '30101810300000000747', address: 'dfgdfhg' },
        { name: 'JJJJddfdf', bic: 'DFGA', city: 'Москва', address: 'dfgdfhg', corrAccount: '30101810300000000747' }
      ],
      columns: [
        {
          name: 'name',
          label: 'Название',
          align: 'left',
          field: 'name'
        },
        { name: 'bic', label: 'БИК', field: 'bic' },
        { name: 'corrAccount', label: 'Корреспонденский счет', field: 'corrAccount' },
        { name: 'city', label: 'Город', field: 'city' },
        { name: 'address', label: 'Адрес', field: 'address' },
        { name: 'saveChanges', label: 'Действия', field: 'saveChanges' }
      ]
    }
  }
}
</script>
